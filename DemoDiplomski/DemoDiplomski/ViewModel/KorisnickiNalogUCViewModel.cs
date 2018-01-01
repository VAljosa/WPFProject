using DemoDiplomski.Model;
using DemoDiplomski.Utility;
using DemoDiplomski.ViewModel.ModelVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDiplomski.ViewModel
{
    public class KorisnickiNalogUCViewModel : CrudVMBase
    {

        #region Kolekcije
        private ObservableCollection<KorisnickiNalogVM> korisnickiNalozi = null;
        #endregion

        #region Svojstva-kolekcije
        public ObservableCollection<KorisnickiNalogVM> KorisnickiNalozi { get => korisnickiNalozi; set => SetAndNotify(ref korisnickiNalozi, value); }
        #endregion

        #region Polja
        private KorisnickiNalogVM dodajVM;
        private KorisnickiNalogVM selektovaniNalog;
        #endregion

        #region Svojstva
        public KorisnickiNalogVM DodajVM
        {
            get { return dodajVM; }
            set
            {
                dodajVM = value;
                editovaniEntitet = dodajVM.Model;
                NotifyPropertyChanged();
            }
        }

        public KorisnickiNalogVM SelektovaniNalog
        {
            get { return selektovaniNalog; }
            set
            {
                selektovaniEntitet = value;
                SetAndNotify(ref selektovaniNalog, value);
            }               
        }
        #endregion

        public KorisnickiNalogUCViewModel()
        {
            SelektovaniNalog = new KorisnickiNalogVM();
            KorisnickiNalozi = null;
            DohvatiPodatke();
            InicijalizujKomande();
        }

        #region Komande
        public RelayCommand DodajNalog { get; set; }
        public RelayCommand AzurirajPostojeciNalog { get; set; }
        public RelayCommand ObrisiNalog { get; set; }
        public RelayCommand DodajAzurirajNalog { get; set; }
        public RelayCommand SacuvajKN { get; set; }
        #endregion

        private void InicijalizujKomande()
        {
            this.DodajNalog = new RelayCommand
            (
               delegate(object o)
               {
                   DodajVM = new KorisnickiNalogVM();
                   JeUEditModu = true;

               },
               o => true
            );

            this.AzurirajPostojeciNalog = new RelayCommand
            (
               delegate(object o)
               {
                   DodajVM = SelektovaniNalog;
                   JeUEditModu = true;
               },
               o => true
            );
            this.DodajAzurirajNalog = new RelayCommand
            (
                delegate(object o)
                {
                    DodajAzuriraj();
                },
                o => true
            );
            this.ObrisiNalog = new RelayCommand
            (
                delegate(object o)
                {
                    ObrisiTekuce();
                },
                o => true
            );
            this.SacuvajKN = new RelayCommand
            (
                delegate(object o)
                {
                    if(DodajVM == null || DodajVM.Model == null)
                    {
                        if (db.ChangeTracker.HasChanges())
                        {
                            Sacuvaj();
                        }
                        return;
                    }
                    if (DodajVM.JeNovo)
                    {
                        db.LogKorisnici.Add(DodajVM.Model);
                        KorisnickiNalozi.Add(DodajVM);
                        Sacuvaj();
                    }
                    else if (db.ChangeTracker.HasChanges())
                    {
                        Sacuvaj();
                    }
                    else
                    {
                        PrikaziUIPoruku("Nalog nije kreiran");
                    }
                },
                o => true
            );
        }

        protected override void Sacuvaj()
        {
            try
            {
                db.SaveChanges();
                PrikaziUIPoruku("Kreiran je novi nalog");
            }
            catch (Exception e)
            {

                PrikaziUIPoruku(e.Message);
            }
        }

        protected override void DodajAzuriraj()
        {
            if (JeSelektovaniObj())
            {
                DodajVM = SelektovaniNalog;
                JeUEditModu = true;
            }
            else
            {
                DodajVM = new KorisnickiNalogVM();
                JeUEditModu = true;
            }
        }

        protected override void ObrisiTekuce()
        {
            if (JeSelektovaniObj())
            {
                db.LogKorisnici.Remove(SelektovaniNalog.Model);
                KorisnickiNalozi.Remove(SelektovaniNalog);
                NotifyPropertyChanged("KorisnickiNalozi");
                Sacuvaj();
                selektovaniEntitet = null;
                PrikaziUIPoruku("Nalog je izbrisan");
            }
        }

        protected override async void DohvatiPodatke()
        {
            ObservableCollection<KorisnickiNalogVM> korisnickiNalozi_KN = new ObservableCollection<KorisnickiNalogVM>();
            var nalogUpit = await (from n in db.LogKorisnici
                                   orderby n.Ime
                                   select n).ToListAsync();
            foreach(LogKorisnik logKorisnik in nalogUpit)
            {
                korisnickiNalozi_KN.Add(new KorisnickiNalogVM() { JeNovo = false, Model = logKorisnik });
            }
            KorisnickiNalozi = korisnickiNalozi_KN;
        }
    }
}
