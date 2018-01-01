using DemoDiplomski.Model;
using DemoDiplomski.ViewModel.ModelVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.Entity.Validation;
using System.Collections;

namespace DemoDiplomski.ViewModel
{
    public class DeloviUCViewModel : CrudVMBase
    {

        //ObservableCollection i tekuciDeo nisu vise tipa DeoVM nego Deo, direktno iz modela
        //Kolekcija bi trebalo da bude tipa omotaca UredjajVM, DeloviVM....??

        #region polja
        //private ICollectionView deoCV;
        //private CollectionViewSource cvsDeo;
        private DeoVM selektovaniDeo;
        private UredjajVM selektovaniUredjaj;
        private DeoVM dodajVM;
        #endregion

        #region Svojstva
        public ObservableCollection<DeoVM> DeloviKolekcija
        {
            get
            {
                return deloviKolekcija;
            }

            set
            {
                SetAndNotify(ref deloviKolekcija, value);
            }
        }
        public DeoVM SelektovaniDeo
        {
            get
            {
                return selektovaniDeo;
            }

            set
            {
                selektovaniEntitet = value;
                SetAndNotify(ref selektovaniDeo, value);
            }
        }
        public UredjajVM SelektovaniUredjaj
        {
            get
            {
                return selektovaniUredjaj;
            }

            set
            {
                SetAndNotify(ref selektovaniUredjaj, value);
            }
        }
        public ObservableCollection<UredjajVM> UredjajiKolekcija
        {
            get
            {
                return uredjajiKolekcija;
            }

            set
            {
                SetAndNotify(ref uredjajiKolekcija, value);
            }
        }
        public DeoVM DodajVM
        {
            get
            {
                return dodajVM;
            }

            set
            {
                SetAndNotify(ref dodajVM, value);
            }
        }
        #endregion

        #region Kolekcije
        private ObservableCollection<DeoVM> deloviKolekcija = new ObservableCollection<DeoVM>();
        private ObservableCollection<UredjajVM> uredjajiKolekcija = new ObservableCollection<UredjajVM>();
        #endregion


        public DeloviUCViewModel()
        {
            db = new TehnoklinikModel();
            SelektovaniDeo = new DeoVM();
            SelektovaniUredjaj = new UredjajVM();
            deloviKolekcija = null;
            DohvatiPodatke();
            IzvrsiKomande();
        }

        #region Komande
        //public RelayCommand DodajDelove { get; set; }
        public RelayCommand DodajDeo { get; set; }
        public RelayCommand AzurirajD { get; set; }
        public RelayCommand SacuvajD { get; set; }
        public RelayCommand IzbrisiD { get; set; }
        public RelayCommand PrimeniFilter { get; set; }
        #endregion


        private void IzvrsiKomande()
        {
            this.PrimeniFilter = new RelayCommand
            (
                delegate (object o)
                {
                    Primenifiltriranje();
                },
                o => true
            );

            this.DodajDeo = new RelayCommand
            (
                delegate (object o)
                {
                    DodajVM = new DeoVM();
                    JeUEditModu = true;
                },
                o => true
            );
            this.AzurirajD = new RelayCommand
            (
                delegate(object o)
                {
                    if (JeSelektovaniObj())
                    {
                        DodajVM = SelektovaniDeo;
                        JeUEditModu = true;
                    }
                },
                o => true
            );

            this.SacuvajD = new RelayCommand
            (
                delegate(object o)
                {
                    if(DodajVM == null || DodajVM == null)
                    {
                        if (db.ChangeTracker.HasChanges())
                        {
                            Sacuvaj();
                        }
                        return;
                    }
                    if (DodajVM.JeNovo)
                    {
                        DodajVM.JeNovo = false;
                        DeloviKolekcija.Add(DodajVM);
                        db.Delovi.Add(DodajVM.Model);
                        Sacuvaj();
                    }else if (db.ChangeTracker.HasChanges())
                    {
                        Sacuvaj();
                    }else
                    {
                        PrikaziUIPoruku("Promene nisu unete");
                    }
                },
                o => true 
            );
            this.IzbrisiD = new RelayCommand
            (
                delegate(object o) 
                {
                    ObrisiTekuce();
                },
                o => true
            );
        }

        protected override void ObrisiTekuce()
        {
            if (JeSelektovaniObj())
            {
                db.Delovi.Remove(SelektovaniDeo.Model);
                DeloviKolekcija.Remove(SelektovaniDeo);
                NotifyPropertyChanged("Delovi");
                Sacuvaj();
                selektovaniEntitet = null;

            }
        }

        protected override void Sacuvaj()
        {
            try
            {
                db.SaveChanges();
                PrikaziUIPoruku("Baza podataka je azurirana");
            }
            catch (Exception ex)
            {

                if (Debugger.IsAttached)
                {
                    ErrorPoruka = ex.InnerException.GetBaseException().ToString();
                }
                PrikaziUIPoruku("Problem prilikom ažuriranja baze podataka!");
            }
        }

        protected override async void DohvatiPodatke()
        {
            ObservableCollection<DeoVM> delovi_D = new ObservableCollection<DeoVM>();
            var deoQuery = await (from d in db.Delovi
                                  select d).ToListAsync();
            await Task.Delay(10);
            foreach (Deo d in deoQuery)
            {
                delovi_D.Add(new DeoVM { Model = d});
            }

            DeloviKolekcija = delovi_D;

            var uredjajUpit = await (from u in db.Uredjaji
                                     select u).ToListAsync();
            await Task.Delay(10);
            foreach (Uredjaj u in uredjajUpit)
            {
                UredjajiKolekcija.Add(new UredjajVM { Model = u});
            }//Smestanje kolekcije u VIew
            UredjajiView = CollectionViewSource.GetDefaultView(UredjajiKolekcija) as ListCollectionView;
            UredjajiView.CustomSort = new UredjajiComparer();
            NotifyPropertyChanged("UredjajiView");
        }

        #region Filter

        private UredjajVM serijskiBrojFilter;
        private UredjajVM tipFilter;

        public UredjajVM SerijskiBrojFilter
        {
            get
            {
                return serijskiBrojFilter;
            }

            set
            {
                serijskiBrojFilter = value;
                NotifyPropertyChanged();
            }
        }
        public UredjajVM TipFilter
        {
            get
            {
                return tipFilter;
            }

            set
            {
                tipFilter = value;
                NotifyPropertyChanged();
            }
        }

        private UredjajVM TekuciUredjaj
        {
            get { return UredjajiView.CurrentItem as UredjajVM; }
        }

        private List<Predicate<UredjajVM>> kriterijum = new List<Predicate<UredjajVM>>();       
        public ListCollectionView UredjajiView { get; set; }

        private void Primenifiltriranje()
        {
            kriterijum.Clear();
            if(TipFilter != null)
            {
                kriterijum.Add(new Predicate<UredjajVM>(x => x.Model.Tip.StartsWith(TipFilter.Model.Tip)));
            }
            if(SerijskiBrojFilter != null)
            {
                kriterijum.Add(new Predicate<UredjajVM>(x => x.Model.S_N.StartsWith(SerijskiBrojFilter.Model.S_N)));
            }

            UredjajiView.Filter = FilterUredjaj;
            NotifyPropertyChanged("UredjajView");

            if (TekuciUredjaj != null)
            {
                UredjajVM tekuci = TekuciUredjaj;
                UredjajiView.MoveCurrentToFirst();
                UredjajiView.MoveCurrentTo(tekuci);
            }
        }

        //dynamicFilter omogucava korisniku da bira selektovan kriterijum i filtrira bilo koju grupu podataka 
        private bool FilterUredjaj(object objekat)//Param FiltrirajNalogePoRednomBroju metodi kod uredjaja i korisnika
        {
            UredjajVM uredjajVM = objekat as UredjajVM;
            bool aktivan = true;
            if (kriterijum.Count() == 0)
                return aktivan;
            aktivan = kriterijum.TrueForAll(x => x(uredjajVM));
            return aktivan;
            //if (this.SerijskiBrojFilter == null)
            //    return aktivan;
            //aktivan = kriterijum.TrueForAll(x => x(uredjajVM));
            //if (TipFilter == null)
            //    return aktivan;
            //aktivan = kriterijum.TrueForAll(x => x(uredjajVM));
            //return aktivan;
            //return (this.SerijskiBrojFilter != null ? uredjajVM.Model.IDUredjaj == this.SerijskiBrojFilter.Model.IDUredjaj : true)
            //    || (this.TipFilter != null ? uredjajVM.Model.IDUredjaj == this.TipFilter.Model.IDUredjaj : true);
        }

        //Kastomizovano sortiranje, primarno sortiranje se vrsi nad tipom podatka 'Model.Tip', pa onda nad tipom 'Model.S_N(Serial number)'
        //UredjajiComarer nasledjuje interfejs IComparer
        private class UredjajiComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                UredjajVM u1 = x as UredjajVM;
                UredjajVM u2 = x as UredjajVM;

                int rezultat = u1.Model.Tip.CompareTo(u2.Model.Tip);
                if (rezultat == 0)
                {
                    rezultat = u1.Model.S_N.CompareTo(u2.Model.S_N);
                }
                return rezultat;
            }
        }

        #endregion


    }
}
