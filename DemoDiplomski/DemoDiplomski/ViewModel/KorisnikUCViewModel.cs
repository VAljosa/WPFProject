using DemoDiplomski.Model;
using DemoDiplomski.ViewModel.ModelVM;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DemoDiplomski.ViewModel;
using System.Diagnostics;
using System.IO;

namespace DemoDiplomski.ViewModel
{
    public class KorisnikUCViewModel : CrudVMBase
    {

        #region Kolekcije
        private ObservableCollection<KorisnikVM> korisniciKolekcija = null;
        private ObservableCollection<DostavnicaVM> dostavnice = new ObservableCollection<DostavnicaVM>();
        private ObservableCollection<ReversVM> reversi = new ObservableCollection<ReversVM>();
        private ObservableCollection<NalogVM> radniNalozi = new ObservableCollection<NalogVM>();
        #endregion

        #region Svojstva-kolekcije
        public ObservableCollection<KorisnikVM> KorisniciKolekcija
        {
            get
            {
                return korisniciKolekcija;
            }

            set
            {
                SetAndNotify(ref korisniciKolekcija, value);
            }
        }
        public ObservableCollection<DostavnicaVM> Dostavnice
        {
            get
            {
                return dostavnice;
            }

            set
            {
                SetAndNotify(ref dostavnice, value);
            }
        }
        public ObservableCollection<ReversVM> Reversi
        {
            get
            {
                return reversi;
            }

            set
            {
                SetAndNotify(ref reversi, value);
            }
        }
        public ObservableCollection<NalogVM> RadniNalozi
        {
            get
            {
                return radniNalozi;
            }

            set
            {
                SetAndNotify(ref radniNalozi, value);
            }
        }
        #endregion

        #region Polja
        private KorisnikVM selektovaniKorisnik;
        private UredjajVM selektovaniUredjaj;
        private DostavnicaVM selektovanaDostavnica;
        private RedovanServisVM selektovaniRedovanServisVM;
        private ReversVM selektovaniRevers;
        private NalogVM selektovaniNalog;
        private KorisnikVM dodajVM;//editVM
        ListCollectionView korisniciView;
        private string savePoruka;
        #endregion

        #region Polja-Filter
        private ReversVM reversFilterBrRevers;
        private ReversVM reversFilterGrad;
        private DostavnicaVM dostavnicaFilterBrDostavnica;
        private DostavnicaVM dostavnicaFilterGrad;
        private NalogVM naloziFilterBrNalog;
        private NalogVM naloziFilterKorisnikGrad;
        private NalogVM naloziFilterRedovanServis;
        private NalogVM servisFilter;

        public ListCollectionView radniNaloziView;
        public ListCollectionView reversiView;
        public ListCollectionView dostavniceView;
        #endregion

        #region Polja-Svojstva
        public KorisnikVM SelektovaniKorisnik
        {
            get
            {
                return selektovaniKorisnik;
            }

            set
            {
                selektovaniEntitet = value;
                SetAndNotify(ref selektovaniKorisnik, value);
            }
        }
        public DostavnicaVM SelektovanaDostavnica
        {
            get
            {
                return selektovanaDostavnica;
            }

            set
            {
                SetAndNotify(ref selektovanaDostavnica, value);
            }
        }
        public RedovanServisVM SelektovaniRedovanServisVM
        {
            get
            {
                return selektovaniRedovanServisVM;
            }

            set
            {
                SetAndNotify(ref selektovaniRedovanServisVM, value);
            }
        }
        public ReversVM SelektovaniRevers
        {
            get
            {
                return selektovaniRevers;
            }

            set
            {
                SetAndNotify(ref selektovaniRevers, value);
            }
        }
        public UredjajVM SelektovaniUredjaj
        {
            get { return selektovaniUredjaj; }
            set
            {
                SetAndNotify(ref selektovaniUredjaj, value);
            }
        }
        public NalogVM SelektovaniNalog { get => selektovaniNalog; set => SetAndNotify(ref selektovaniNalog, value); }
        public string SavePoruka
        {
            get
            {
                return savePoruka;
            }

            set
            {
                SetAndNotify(ref savePoruka, value);
            }
        }
        public KorisnikVM DodajVM
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
        public ListCollectionView KorisniciView { get => korisniciView; set => SetAndNotify(ref korisniciView, value); }
        #endregion

        #region Filter-Svojstva
        public NalogVM NaloziFilterBrNalog { get => naloziFilterBrNalog; set => SetAndNotify(ref naloziFilterBrNalog, value); }
        public NalogVM NaloziFilterRedovanServis { get => naloziFilterRedovanServis; set => SetAndNotify(ref naloziFilterRedovanServis, value); }
        public NalogVM NaloziFilterKorisnikGrad { get => naloziFilterKorisnikGrad; set => naloziFilterKorisnikGrad = value; }
        public ReversVM ReversFilterBrRevers { get => reversFilterBrRevers; set => SetAndNotify(ref reversFilterBrRevers, value); }
        public ReversVM ReversFilterGrad { get => reversFilterGrad; set => SetAndNotify(ref reversFilterGrad, value); }
        public DostavnicaVM DostavnicaFilterBrDostavnica { get => dostavnicaFilterBrDostavnica; set => SetAndNotify(ref dostavnicaFilterBrDostavnica, value); }
        public DostavnicaVM DostavnicaFilterGrad { get => dostavnicaFilterGrad; set => SetAndNotify(ref dostavnicaFilterGrad, value); }
        public NalogVM ServisFilter { get => servisFilter; set => SetAndNotify(ref servisFilter, value); }
        #endregion

        #region Komande
        public RelayCommand DodajAzurirajK { get; set; }
        public RelayCommand DodajKorisnika { get; set; }
        public RelayCommand AzurirajK { get; set; }
        public RelayCommand SacuvajK { get; set; }
        public RelayCommand Izbrisi { get; set; }
        public RelayCommand IzadjiK { get; set; }
        public RelayCommand FiltrirajNalog { get; set; }
        public RelayCommand FiltrirajRevers { get; set; }
        public RelayCommand FiltrirajDostavnica { get; set; }
        public RelayCommand DostavnicaMerge { get; set; }
        public RelayCommand ReversMerge { get; set; }
        public RelayCommand RadniNalogMerge { get; set; }
        public RelayCommand PonistiFilterRadniNalog { get; set; }
        #endregion

        public KorisnikUCViewModel()
        {
            SelektovaniKorisnik = new KorisnikVM();
            SelektovaniRevers = new ReversVM();
            SelektovanaDostavnica = new DostavnicaVM();
            SelektovaniRedovanServisVM = new RedovanServisVM();
            korisniciKolekcija = null;
            DohvatiPodatke();
            IzvrsiKomande();
        }

        #region FilterMethod

        private NalogVM TekuciNalog { get => radniNaloziView.CurrentItem as NalogVM; }
        private ReversVM TekuciRevers { get => reversiView.CurrentItem as ReversVM; }
        private DostavnicaVM TekucaDostavnica { get => dostavniceView.CurrentItem as DostavnicaVM; }

        private List<Predicate<NalogVM>> kriterijumNalog = new List<Predicate<NalogVM>>();
        private List<Predicate<ReversVM>> kriterijumRevers = new List<Predicate<ReversVM>>();
        private List<Predicate<DostavnicaVM>> kriterijumDostavnica = new List<Predicate<DostavnicaVM>>();
        

        private void PrimeniFilterNalog()
        {
            kriterijumNalog.Clear();
            if (this.NaloziFilterBrNalog != null)
                kriterijumNalog.Add(new Predicate<NalogVM>(x => 
                x.Model.BrRadNalog.StartsWith(NaloziFilterBrNalog.Model.BrRadNalog)));
            if (this.ServisFilter != null)
                kriterijumNalog.Add(new Predicate<NalogVM>(x => 
                x.Model.Komentar.StartsWith(ServisFilter.Model.Komentar)));

            radniNaloziView.Filter = this.FilterNalog;
            NotifyPropertyChanged("radniNaloziView");
            
            if(TekuciNalog != null)
            {
                NalogVM tekuciNalog = this.TekuciNalog;
                radniNaloziView.MoveCurrentToFirst();
                radniNaloziView.MoveCurrentTo(tekuciNalog);
            }
        }
        bool FilterNalog(object obj)//Pretrazuje po ID-u
        {
            NalogVM nalogVM = obj as NalogVM;
            bool aktivan = true;
            if (kriterijumNalog.Count() == 0)
                return aktivan;
            aktivan = kriterijumNalog.TrueForAll(x => x(nalogVM));
            return aktivan;
            //if (this.NaloziFilterBrNalog == null)
            //    return true;
            //return (this.NaloziFilterBrNalog != null ? nalogVM.Model.IDNalog == this.NaloziFilterBrNalog.Model.IDNalog : true)
            //    || (this.NaloziFilterKorisnikGrad != null ? nalogVM.Model.Korisnik.IDKorisnik == this.NaloziFilterKorisnikGrad.Model.Korisnik.IDKorisnik : true);
            ////&& drugi uslov
            ////&& treci uslov
        }


        private void PrimeniFilterRevers()
        {
            kriterijumRevers.Clear();
            if (this.ReversFilterBrRevers != null)
                kriterijumRevers.Add(new Predicate<ReversVM>(x => 
                x.Model.BrRevers.StartsWith(ReversFilterBrRevers.Model.BrRevers)));
            if (this.ReversFilterGrad != null)
                kriterijumRevers.Add(new Predicate<ReversVM>(x => 
                x.Model.Korisnik.Grad.StartsWith(ReversFilterGrad.Model.Korisnik.Grad)));

            reversiView.Filter = FilterRevers;
            NotifyPropertyChanged("reversiView");

            if(TekuciRevers != null)
            {
                ReversVM tekuciRevers = this.TekuciRevers;
                reversiView.MoveCurrentToFirst();
                reversiView.MoveCurrentTo(tekuciRevers);
            }
        }

        bool FilterRevers(object obj)
        {
            ReversVM reversVM = obj as ReversVM;
            bool aktivan = true;
            if (kriterijumRevers.Count() == 0)
                return aktivan;
            aktivan = kriterijumRevers.TrueForAll(x => x(reversVM));
            return aktivan;
            //    return true;
            //return (this.ReversFilterBrRevers != null ? reversVM.Model.IDRevers == this.ReversFilterBrRevers.Model.IDRevers : true)
            //    || (this.ReversFilterGrad != null ? reversVM.Model.Korisnik.IDKorisnik == this.ReversFilterGrad.Model.Korisnik.IDKorisnik : true);
        }

        private void PrimeniFilterDostavnica()
        {
            kriterijumDostavnica.Clear();
            if (this.DostavnicaFilterBrDostavnica != null)
                kriterijumDostavnica.Add(new Predicate<DostavnicaVM>(x => 
                x.Model.BrDostavnica.StartsWith(this.DostavnicaFilterBrDostavnica.Model.BrDostavnica)));

            if (this.DostavnicaFilterGrad != null)
                kriterijumDostavnica.Add(new Predicate<DostavnicaVM>(x => 
                x.Model.Korisnik.Grad.StartsWith(this.DostavnicaFilterGrad.Model.Korisnik.Grad)));

            dostavniceView.Filter = FilterDostavnica;
            NotifyPropertyChanged("dostavniceView");

            if(TekucaDostavnica != null)
            {
                DostavnicaVM tekucaDostavnica = this.TekucaDostavnica;
                dostavniceView.MoveCurrentToFirst();
                dostavniceView.MoveCurrentTo(tekucaDostavnica);
            }
        }


        bool FilterDostavnica(object obj)
        {
            DostavnicaVM dostavnicaVM = obj as DostavnicaVM;
            bool aktivan = true;
            if (kriterijumDostavnica.Count() == 0)
                return aktivan;
            aktivan = kriterijumDostavnica.TrueForAll(x => x(dostavnicaVM));
            return aktivan;
            //if (this.DostavnicaFilterBrDostavnica == null)
            //    return true;
            //return (this.DostavnicaFilterBrDostavnica != null ? dostavnicaVM.Model.IDDostavnica == this.DostavnicaFilterBrDostavnica.Model.IDDostavnica : true)
            //    || (this.DostavnicaFilterGrad != null ? dostavnicaVM.Model.Korisnik.IDKorisnik == this.DostavnicaFilterGrad.Model.Korisnik.IDKorisnik : true);
        }
        #endregion


        public void IzvrsiKomande()
        {
            this.FiltrirajNalog = new RelayCommand
            (
                delegate (object o)
                {
                    //radniNaloziView.Refresh();
                    PrimeniFilterNalog();
                },
                o => true
            );
            this.FiltrirajRevers = new RelayCommand
            (
                delegate (object o)
                {
                    //reversiView.Refresh();
                    PrimeniFilterRevers();
                },
                o => true
            );
            this.FiltrirajDostavnica = new RelayCommand
            (
                delegate (object o)
                {
                    //dostavniceView.Refresh();
                    PrimeniFilterDostavnica();
                },
                o => true
            );
            this.PonistiFilterRadniNalog = new RelayCommand
            (
                delegate(object o)
                {
                    radniNaloziView.Refresh();
                },
                o => true
            );

            this.DodajAzurirajK = new RelayCommand
            (
                delegate(object o)
                {
                    DodajAzuriraj();
                },
                o => true
            );

            this.DodajKorisnika = new RelayCommand
            (
                delegate (object o)
                {
                    DodajVM = new KorisnikVM();
                    JeUEditModu = true;
                },
                o => true
            );
            this.AzurirajK = new RelayCommand
            (
                delegate(object o)
                {
                    if (JeSelektovaniObj())
                    {
                        DodajVM = SelektovaniKorisnik;
                        JeUEditModu = true;
                    }
                },
                o => true
            );
            this.SacuvajK = new RelayCommand
            (
                delegate (object o)
                {
                    if (DodajVM == null || DodajVM.Model == null)
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
                        KorisniciKolekcija.Add(DodajVM);
                        db.Korisnici.Add(DodajVM.Model);
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
            this.Izbrisi = new RelayCommand
            (
                delegate (object o)
                {
                    ObrisiTekuce();
                },
                o => true
            );

            this.DostavnicaMerge = new RelayCommand
            (
                delegate(object o)
                {
                    DostavnicaPodaci();
                },
                o => true
            );
            this.ReversMerge = new RelayCommand
            (
                delegate(object o)
                {
                    ReversPodaci();
                },
                o => true
            );
            this.RadniNalogMerge = new RelayCommand
            (
                delegate(object o)
                {
                    RadniNalogPodaci();
                }
            );
        }

        //Za potrebe unosa kontekst menija
        protected override void DodajAzuriraj()
        {
            if (JeSelektovaniObj())
            {
                DodajVM = SelektovaniKorisnik;
                JeUEditModu = true;
            }
            else
            {
                DodajVM = new KorisnikVM();
                JeUEditModu = true;

            }
        }
        protected override void ObrisiTekuce()
        {
            if (JeSelektovaniObj())
            {
                int brUredjaja = BrojUredjaja();
                int brDostavnica = BrojDostavnica();
                int brReversa = BrojReversa();

                if (brUredjaja > 0)
                {
                    PrikaziUIPoruku(string.Format("Brisanje nije moguće, postoji {0} uređaja kod ovog korisnika", brUredjaja));
                }
                else if (brDostavnica > 0)
                {
                    PrikaziUIPoruku(string.Format("Brisanje nije moguće, postoji {0} aktivnih dostavnica kod ovog korisnika", brDostavnica));
                }
                else if (brReversa > 0)
                {
                    PrikaziUIPoruku(string.Format("Brisanje nije moguće, postoji {0} reversa u evidenciji", brReversa));
                }
                else
                {
                    db.Korisnici.Remove(SelektovaniKorisnik.Model);
                    KorisniciKolekcija.Remove(SelektovaniKorisnik);
                    NotifyPropertyChanged("KorisniciKolekcija");
                    Sacuvaj();
                    selektovaniEntitet = null;
                    PrikaziUIPoruku("Podaci su obrisani");
                }
            }

        }

        protected override void Sacuvaj()
        {
            try
            {
                db.SaveChanges();
                PrikaziUIPoruku("Korisnici su ažurirani");

            }
            catch (Exception)
            {
                PrikaziUIPoruku("Unesite podatke u polja!");
            }
        }

        public override void OsveziPodatke()
        {
            DohvatiPodatke();
        }

        //provera zavisnosti izmedju entiteta
        private int BrojUredjaja()
        {
            var korisnik = db.Korisnici.Find(SelektovaniKorisnik.Model.IDKorisnik);
            int brUredjaj = db.Entry(korisnik)
                            .Collection(x => x.Uredjaji)
                            .Query()
                            .Count();
            return brUredjaj;
        }
        private int BrojNaloga()
        {
            var korisnik = db.Korisnici.Find(SelektovaniKorisnik.Model.IDKorisnik);
            int brNalog = db.Entry(korisnik)
                            .Collection(x => x.Nalozi)
                            .Query()
                            .Count();
            return brNalog;
        }
        private int BrojDostavnica()
        {
            var korisnik = db.Korisnici.Find(SelektovaniKorisnik.Model.IDKorisnik);
            int brDostavnice = db.Entry(korisnik)
                                 .Collection(x => x.Dostavnice)
                                 .Query()
                                 .Count();
            return brDostavnice;
        }
        private int BrojReversa()
        {
            var korisnik = db.Korisnici.Find(SelektovaniKorisnik.Model.IDKorisnik);
            int brReversa = db.Entry(korisnik)
                              .Collection(x => x.Dostavnice)
                              .Query()
                              .Count();
            return brReversa;
        }

        protected override async void DohvatiPodatke()
        {
            ObservableCollection<KorisnikVM> korisnici_K = new ObservableCollection<KorisnikVM>();
            var korisnikUpit = await (from k in db.Korisnici
                                      orderby k.Grad
                                      select k).ToListAsync();
            await Task.Delay(10);
            foreach (Korisnik k in korisnikUpit)
            {
                korisnici_K.Add(new KorisnikVM() { JeNovo = false, Model = k });
            }
            KorisniciKolekcija = korisnici_K;

            var dostavnicaUpit = await (from d in db.Dostavnice
                                        select d).ToListAsync();

            //var dostavnicaUpit = await (from d in db.Dostavnice
            //                            join k in db.Korisnici
            //                            on d.IDKorisnik equals k.IDKorisnik
            //                            join u in db.Uredjaji
            //                            on k.IDKorisnik equals u.IDKorisnik
            //                            select new { d.BrDostavnica, d.Datum, u.S_N, u.Tip, k.NazivUstanove, k.Grad }).ToListAsync();
            //await Task.Delay(30);
            foreach (Dostavnica d in dostavnicaUpit)
            {
                Dostavnice.Add(new DostavnicaVM { Model = d});
            }
            dostavniceView = CollectionViewSource.GetDefaultView(this.Dostavnice) as ListCollectionView;

            var reversUpit = await (from r in db.Reversi
                                     select r).ToListAsync();
            //var reversUpit = await (from r in db.Reversi
            //                        join k in db.Korisnici
            //                        on r.IDKorisnik equals k.IDKorisnik
            //                        join u in db.Uredjaji
            //                        on r.IDKorisnik equals u.IDKorisnik
            //                        select new { r.BrRevers, r.Datum, u.S_N, u.Tip, k.NazivUstanove, k.Grad }).ToListAsync();
            //await Task.Delay(50);
            foreach (Revers r in reversUpit)
            {
                Reversi.Add(new ReversVM { Model = r});
            }
            reversiView = CollectionViewSource.GetDefaultView(this.Reversi) as ListCollectionView;


            var upitNalozi = await (from nalog in db.Nalozi
                                    select nalog).ToListAsync();
            //var upitNalozi = await (from n in db.Nalozi
            //                        join k in db.Korisnici
            //                        on n.IDKorisnik equals k.IDKorisnik
            //                        select new { n.BrRadNalog, n.Datum, n.Komentar, k.NazivUstanove, k.Laboratorija, k.Grad }).ToListAsync();
            //await Task.Delay(70);
            foreach (Nalog n in upitNalozi)
            {
                RadniNalozi.Add(new NalogVM { Model = n });
            }

            radniNaloziView = CollectionViewSource.GetDefaultView(this.RadniNalozi) as ListCollectionView;
        }

        #region PosaljiUWord
        public void DostavnicaPodaci()
        {
            string nazivUstanove = SelektovanaDostavnica.Model.Korisnik.NazivUstanove;
            int pib = SelektovanaDostavnica.Model.Korisnik.PIB;
            string adresa = SelektovanaDostavnica.Model.Korisnik.Adresa;
            string telefon = SelektovanaDostavnica.Model.Korisnik.Telefon;
            int postanskiBroj = SelektovanaDostavnica.Model.Korisnik.PostanskiBroj;
            string grad = SelektovanaDostavnica.Model.Korisnik.Grad;
            string drzava = SelektovanaDostavnica.Model.Korisnik.Drzava;
            string brDostavnice = SelektovanaDostavnica.Model.BrDostavnica;
            DateTime datum = DateTime.Now;
            


            var wordApp = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();

            string dostavnicaDotx = "DostavnicaTemplate.dotx";
            string lokacija = Path.Combine(Environment.CurrentDirectory, @"Resources\Word\", dostavnicaDotx);
            document = wordApp.Documents.Add(lokacija);
            wordApp.Visible = true;

            foreach(Microsoft.Office.Interop.Word.Field field in document.Fields)
            {
                if (field.Code.Text.Contains("NazivUstanove"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(nazivUstanove);
                }
                else if (field.Code.Text.Contains("Pib"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(pib.ToString());
                }
                else if (field.Code.Text.Contains("Telefon"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(telefon);
                }
                else if (field.Code.Text.Contains("Adresa"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(adresa);
                }
                else if (field.Code.Text.Contains("PostanskiBroj"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(postanskiBroj.ToString());
                }
                else if (field.Code.Text.Contains("Grad"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(grad);
                }
                else if (field.Code.Text.Contains("Drzava"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(drzava);
                }
                else if (field.Code.Text.Contains("BrojDostavnice"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(brDostavnice);
                }
                else if (field.Code.Text.Contains("Datum"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(datum.ToString("dd.MM.yyyy."));
                }

            }
        }

        public void ReversPodaci()
        {
            string nazivUstanove = SelektovaniRevers.Model.Korisnik.NazivUstanove;
            int pib = SelektovaniRevers.Model.Korisnik.PIB;
            string telefon = SelektovaniRevers.Model.Korisnik.Telefon;
            string adresa = SelektovaniRevers.Model.Korisnik.Adresa;
            int postanskiBroj = SelektovaniRevers.Model.Korisnik.PostanskiBroj;
            string grad = SelektovaniRevers.Model.Korisnik.Grad;
            string drzava = SelektovaniRevers.Model.Korisnik.Drzava;
            string brDostavnice = SelektovaniRevers.Model.BrRevers;
            DateTime datum = DateTime.Now;


            var wordApp = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();

            string reversDotx = "ReversTemplate.dotx";
            string lokacija = Path.Combine(Environment.CurrentDirectory,
                @"Resources\Word\", reversDotx);
            document = wordApp.Documents.Add(lokacija);
            wordApp.Visible = true;

            foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
            {
                if (field.Code.Text.Contains("NazivUstanove"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(nazivUstanove);
                }
                else if (field.Code.Text.Contains("Pib"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(pib.ToString());
                }
                else if (field.Code.Text.Contains("Telefon"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(telefon);
                }
                else if (field.Code.Text.Contains("Adresa"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(adresa);
                }
                else if (field.Code.Text.Contains("PostanskiBroj"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(postanskiBroj.ToString());
                }
                else if (field.Code.Text.Contains("Grad"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(grad);
                }
                else if (field.Code.Text.Contains("Drzava"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(drzava);
                }
                else if (field.Code.Text.Contains("BrojReversa"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(brDostavnice);
                }
                else if (field.Code.Text.Contains("Datum"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(datum.ToString("dd.MM.yyyy."));
                }



            }

        }

        public void RadniNalogPodaci()
        {
            string nazivUstanove = SelektovaniNalog.Model.Korisnik.NazivUstanove;
            string laboratorija = SelektovaniNalog.Model.Korisnik.Laboratorija;
            string adresa = SelektovaniNalog.Model.Korisnik.Adresa;
            int postanskiBroj = SelektovaniNalog.Model.Korisnik.PostanskiBroj;
            string grad = SelektovaniNalog.Model.Korisnik.Grad;
            string drzava = SelektovaniNalog.Model.Korisnik.Drzava;
            string brRadNalog = SelektovaniNalog.Model.BrRadNalog;
            DateTime datum = DateTime.Now;

            var wordApp = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();

            string radNalogsDotx = "RadNalogTemplate.dotx";
            string lokacija = Path.Combine(Environment.CurrentDirectory, @"Resources\Word\", radNalogsDotx);
            document = wordApp.Documents.Add(lokacija);
            wordApp.Visible = true;

            foreach(Microsoft.Office.Interop.Word.Field field in document.Fields)
            {
                if (field.Code.Text.Contains("NazivUstanove"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(nazivUstanove);
                }
                else if (field.Code.Text.Contains("Laboratorija"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(laboratorija);
                }
                else if (field.Code.Text.Contains("Adresa"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(adresa);
                }
                else if (field.Code.Text.Contains("PostanskiBroj"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(postanskiBroj.ToString());
                }
                else if (field.Code.Text.Contains("Grad"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(grad);
                }
                else if (field.Code.Text.Contains("Drzava"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(drzava);
                }
                else if (field.Code.Text.Contains("BrojRadnogNaloga"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(brRadNalog);
                }
                else if (field.Code.Text.Contains("Datum"))
                {
                    field.Select();
                    wordApp.Selection.TypeText(datum.ToString("dd.MM.yyyy."));
                }

            }
        }
        #endregion

    }
}
