using DemoDiplomski.Model;
using DemoDiplomski.ViewModel.ModelVM;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using System.Windows.Data;

namespace DemoDiplomski.ViewModel
{
    public class UredjajUCViewModel : CrudVMBase
    {

        #region Kolekcije
        private ObservableCollection<UredjajVM> uredjajiKolekcija = new ObservableCollection<UredjajVM>();
        private ObservableCollection<DeoVM> deloviKolekcija = new ObservableCollection<DeoVM>();
        private ObservableCollection<RedovanServisVM> redovniServisiKolekcija = new ObservableCollection<RedovanServisVM>();
        private ObservableCollection<VandredniServisVM> vandredniServisiKolekcija = new ObservableCollection<VandredniServisVM>();
        private ObservableCollection<NalogVM> nalozi = new ObservableCollection<NalogVM>();
        #endregion

        #region CompositeCollection
        //CompositeCollection cc = new CompositeCollection();
        
        #endregion

        #region Polja
        //private CollectionViewSource cvsUredjaj;
        private UredjajVM selektovaniUredjaj;
        private RedovanServisVM selektovanRedovanServis;
        private VandredniServisVM selektovanVandredniServis;
        private DeoVM selektovaniDeo;
        private UredjajVM dodajVM;
        //private ICollectionView uredjajCV;
        #endregion

        #region Polja filter
        private RedovanServisVM rsDatumFilter;
        private RedovanServisVM rsBrojRadnogNaloga;
        private VandredniServisVM vsBrojRadnogNaloga;
        private VandredniServisVM vsDatumFilter;
        private UredjajVM uredjajTipFilter;
        ListCollectionView redovanServisView;
        ListCollectionView vandredniServisView;
        #endregion

        #region Svojstva-filter
        public RedovanServisVM RsDatumFilter { get => rsDatumFilter; set => SetAndNotify(ref rsDatumFilter, value); }
        public RedovanServisVM RsBrojRadnogNaloga { get => rsBrojRadnogNaloga; set => SetAndNotify(ref rsBrojRadnogNaloga, value); }
        public VandredniServisVM VsBrojRadnogNaloga { get => vsBrojRadnogNaloga; set => SetAndNotify(ref vsBrojRadnogNaloga, value); }
        public VandredniServisVM VsDatumFilter { get => vsDatumFilter; set => SetAndNotify(ref vsBrojRadnogNaloga, value); }
        public UredjajVM UredjajTipFilter { get => uredjajTipFilter; set => SetAndNotify(ref uredjajTipFilter, value); }
        #endregion

        #region Svojstva - kolekcije
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
        public ObservableCollection<RedovanServisVM> RedovniServisiKolekcija
        {
            get
            {
                return redovniServisiKolekcija;
            }

            set
            {
                SetAndNotify(ref redovniServisiKolekcija, value);
            }
        }
        public ObservableCollection<VandredniServisVM> VandredniServisiKolekcija
        {
            get
            {
                return vandredniServisiKolekcija;
            }

            set
            {
                SetAndNotify(ref vandredniServisiKolekcija, value);
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
                selektovaniEntitet = value;
                SetAndNotify(ref selektovaniUredjaj, value);
            }
        }
        public RedovanServisVM SelektovanRedovanServis
        {
            get
            {
                return selektovanRedovanServis;
            }

            set
            {
                SetAndNotify(ref selektovanRedovanServis, value);
            }
        }
        public VandredniServisVM SelektovanVandredniServis
        {
            get
            {
                return selektovanVandredniServis;
            }

            set
            {
                SetAndNotify(ref selektovanVandredniServis, value);
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
                SetAndNotify(ref selektovaniDeo, value);
            }
        }
        public UredjajVM DodajVM
        {
            get
            {
                return dodajVM;
            }

            set
            {
                dodajVM = value;
                editovaniEntitet = dodajVM.Model;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Komande
        //public RelayCommand DodajDelove { get; set; }
        public RelayCommand DodajUredjaj { get; set; }
        public RelayCommand AzurirajU { get; set; }
        public RelayCommand SacuvajU { get; set; }
        public RelayCommand IzbrisiU { get; set; }
        public RelayCommand FiltrirajVS { get; set; }
        public RelayCommand FiltrirajRS { get; set; }
        #endregion

        public UredjajUCViewModel()
        {
            db = new TehnoklinikModel();
            SelektovaniUredjaj = new UredjajVM();
            SelektovaniDeo = new DeoVM();
            DohvatiPodatke();
            IzvrsiKomande();
            //cvs = new CollectionViewSource();
            //cvs.Source = Uredjaji;

        }

        private void IzvrsiKomande()
        {
            this.DodajUredjaj = new RelayCommand
           (
               delegate (object o)
               {
                       DodajVM = new UredjajVM();
                       JeUEditModu = true;
               },
               o => true
           );
            this.AzurirajU = new RelayCommand
            (
                delegate(object o)
                {
                    if (JeSelektovaniObj())
                    {
                        DodajVM = SelektovaniUredjaj;
                        JeUEditModu = true;
                    }
                },
                o => true
            );

            this.SacuvajU = new RelayCommand
            (
                delegate (object o)
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
                        DodajVM.JeNovo = false;
                        UredjajiKolekcija.Add(DodajVM);
                        db.Uredjaji.Add(DodajVM.Model);
                        Sacuvaj();
                    }
                    else if (db.ChangeTracker.HasChanges())
                    {
                        Sacuvaj();
                    }
                    else
                    {
                        PrikaziUIPoruku("Promene nisu unete");
                    }
                },
                o => true
            );
            this.IzbrisiU = new RelayCommand
            (
                delegate (object o)
                {
                    ObrisiTekuce();
                },
                o => true
            );
            this.FiltrirajRS = new RelayCommand
            (
                delegate(object o)
                {
                    PrimeniFilterRS();
                },
                o => true
            );
            this.FiltrirajVS = new RelayCommand
            (
                delegate(object o)
                {
                    PrimeniFilterVS();
                },
                o => true
            );
        }

        protected override void ObrisiTekuce()
        {
            if (JeSelektovaniObj())
            {
                int brDostavnica = BrojDostavnica();
                int brRevers = BrojReversa();
                int brNalog = BrojNaloga();
                int vandredniServis = VandredniServis();
                int redovanServis = RedovanServis();

                if(brDostavnica > 0)
                {
                    PrikaziUIPoruku(string.Format("Brisanje nije moguće, postoji {0} aktivnih dostavnica za ovaj uredaj", brDostavnica));
                }
                else if(brRevers > 0)
                {
                    PrikaziUIPoruku(string.Format("Brisanje nije moguće, postoji {0} aktivnih reversa za ovaj uredaj", brRevers));

                }
                else if(brNalog > 0)
                {
                    PrikaziUIPoruku(string.Format("Brisanje nije moguće, postoji {0} aktivnih naloga za ovaj uredaj", brRevers));
                }
                else
                {
                    db.Uredjaji.Remove(SelektovaniUredjaj.Model);
                    UredjajiKolekcija.Remove(SelektovaniUredjaj);
                    NotifyPropertyChanged("Uredjaji");
                    Sacuvaj();
                    selektovaniEntitet = null;

                }
            }
        }

        protected override void Sacuvaj()
        {
            try
            {
                db.SaveChanges();
                PrikaziUIPoruku("Podaci su ažurirani");
            }
            catch (Exception)
            {

                PrikaziUIPoruku("Problem prilikom žuriranja podataka ");
            }
        }

        public override void OsveziPodatke()
        {
            DohvatiPodatke();
        }

        private int BrojDostavnica()
        {
            var uredjaj = db.Uredjaji.Find(SelektovaniUredjaj.Model.IDUredjaj);
            int brDostavnica = db.Entry(uredjaj)
                                 .Collection(x => x.Dostavnice)
                                 .Query()
                                 .Count();
            return brDostavnica;
        }

        private int BrojReversa()
        {
            var uredjaj = db.Uredjaji.Find(SelektovaniUredjaj.Model.IDUredjaj);
            int brReversa = db.Entry(uredjaj)
                              .Collection(x => x.Reversi)
                              .Query()
                              .Count();
            return brReversa;
        }

        private int BrojNaloga()
        {
            var uredjaj = db.Uredjaji.Find(SelektovaniUredjaj.Model.IDUredjaj);
            int brNaloga = db.Entry(uredjaj)
                             .Collection(x => x.Dostavnice)
                             .Query()
                             .Count();
            return brNaloga;
        }

        private int RedovanServis()
        {
            var uredjaj = db.Uredjaji.Find(SelektovaniUredjaj.Model.IDUredjaj);
            int brRedovniServis = db.Entry(uredjaj)
                                    .Collection(x => x.RedovniServisi)
                                    .Query()
                                    .Count();
            return brRedovniServis;                           
        }

        private int VandredniServis()
        {
            var uredjaj = db.Uredjaji.Find(SelektovaniUredjaj.Model.IDUredjaj);
            int brVandredniServis = db.Entry(uredjaj)
                                      .Collection(x => x.VandredniServisi)
                                      .Query()
                                      .Count();
            return brVandredniServis;
        }
        //Treba sefinisati metode za proveru veze izmedju podataka

        //Dohvata uredjaje i prikazuje ih u dataGridu
        protected override async void DohvatiPodatke()
        {
            ObservableCollection<UredjajVM> uredjaji_U = new ObservableCollection<UredjajVM>();
            var uredjajUpit = await(from u in db.Uredjaji
                                    select u).ToListAsync();

            foreach (Uredjaj u in uredjajUpit)
            {
                uredjaji_U.Add(new UredjajVM { Model = u});
            }
            UredjajiKolekcija = uredjaji_U;


            var redovanServisUpit = await (from rs in db.RedovniServisi
                                           select rs).ToListAsync();
            foreach (RedovanServis rs in redovanServisUpit)
                RedovniServisiKolekcija.Add(new RedovanServisVM { Model = rs});

            redovanServisView = CollectionViewSource.GetDefaultView(this.RedovniServisiKolekcija) as ListCollectionView;


            var vandredniServisUpit = await (from vs in db.VandredniServisi
                                             select vs).ToListAsync();
            foreach (VandredniServis vs in vandredniServisUpit)
                VandredniServisiKolekcija.Add(new VandredniServisVM { Model = vs});

            vandredniServisView = CollectionViewSource.GetDefaultView(this.VandredniServisiKolekcija) as ListCollectionView;
        }

        #region Filter
        private RedovanServisVM TekuciRS { get => redovanServisView.CurrentItem as RedovanServisVM; }
        private VandredniServisVM TekuciVS { get => vandredniServisView.CurrentItem as VandredniServisVM; }

        private List<Predicate<RedovanServisVM>> kriterijumRedovanServis = new List<Predicate<RedovanServisVM>>();
        private List<Predicate<VandredniServisVM>> kriterijumVandredniServis = new List<Predicate<VandredniServisVM>>();

        private void PrimeniFilterRS()
        {
            kriterijumRedovanServis.Clear();
            if (this.RsBrojRadnogNaloga != null)
                kriterijumRedovanServis.Add(new Predicate<RedovanServisVM>(x => 
                x.Model.Nalog.BrRadNalog.StartsWith(this.RsBrojRadnogNaloga.Model.Nalog.BrRadNalog)));

            //kriterijum za filtriranje datuma
            if (this.RsDatumFilter != null)
                kriterijumRedovanServis.Add(new Predicate<RedovanServisVM>(x =>
                x.Model.DatumSledecegServisa.Year.Equals(this.RsDatumFilter.Model.DatumSledecegServisa.Year)));


            redovanServisView.Filter = this.FilterRS;
            NotifyPropertyChanged("redovanServisView");

            if(TekuciRS != null)
            {
                RedovanServisVM tekukiRS = this.TekuciRS;
                redovanServisView.MoveCurrentToFirst();
                redovanServisView.MoveCurrentTo(tekukiRS);
            }
        }
        bool FilterRS(object obj)
        {
            RedovanServisVM redovanServisVM = obj as RedovanServisVM;
            bool aktivan = true;
            if (kriterijumRedovanServis.Count() == 0)
                return aktivan;
            aktivan = kriterijumRedovanServis.TrueForAll(x => x(redovanServisVM));
            return aktivan;
        }

        private void PrimeniFilterVS()
        {
            kriterijumVandredniServis.Clear();
            if (this.VsBrojRadnogNaloga != null)
                kriterijumVandredniServis.Add(new Predicate<VandredniServisVM>(x => 
                x.Model.Nalog.BrRadNalog.StartsWith(this.VsBrojRadnogNaloga.Model.Nalog.BrRadNalog)));

            //kriterijum za filtriranje datuma
            if (this.VsDatumFilter != null)
                kriterijumVandredniServis.Add(new Predicate<VandredniServisVM>(x =>
                x.Model.DatumServisa.Year.Equals(this.VsDatumFilter.Model.DatumServisa.Year)));

            vandredniServisView.Filter = this.FilterVS;
            NotifyPropertyChanged("vandredniServisView");

            if(TekuciVS != null)
            {
                VandredniServisVM tekuciVS = this.TekuciVS;
                vandredniServisView.MoveCurrentToFirst();
                vandredniServisView.MoveCurrentTo(tekuciVS);
            }
        }
        bool FilterVS(object obj)
        {
            VandredniServisVM vandredniServisVM = obj as VandredniServisVM;
            bool aktivan = true;
            if (kriterijumVandredniServis.Count() == 0)
                return aktivan;
            aktivan = kriterijumVandredniServis.TrueForAll(x => x(vandredniServisVM));
            return aktivan;
        }
        #endregion




    }
}
