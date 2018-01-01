using DemoDiplomski.Model;
using DemoDiplomski.ViewModel.ModelVM;
using DemoDiplomski.Properties;
using DemoDiplomski.ViewModel;
using DemoDiplomski.View;
using DemoDiplomski.ViewControl;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml;

namespace DemoDiplomski.ViewModel
{
    public class MainWindowViewModel : CrudVMBase
    {

        #region CollectionViewKod
        public ObservableCollection<Uredjaj> Uredjaji { get; set; }
        public CollectionView UredjajiViewNivo { get; set; }
        public CollectionView UredjajView { get; set; }
        private KorisnikVM tekuciKorisnik;
        #endregion

        #region polja
        private KorisnikUCViewModel korisnikViewModelUC;
        private UredjajUCViewModel uredjajViewModelUC;
        private DeloviUCViewModel deoViewModelUC;
        private KorisnikVM selektovaniKorisnik;
        private int selektovaniVMIndex;
        private object tekuciUC;
        #endregion

        #region Svojstva
        public KorisnikUCViewModel KorisnikViewModelUC
        {
            get
            {
                return korisnikViewModelUC;
            }

            set
            {
                SetAndNotify(ref korisnikViewModelUC, value);
            }
        }
        public UredjajUCViewModel UredjajViewModelUC
        {
            get
            {
                return uredjajViewModelUC;
            }

            set
            {
                SetAndNotify(ref uredjajViewModelUC, value);
            }
        }
        public DeloviUCViewModel DeoViewModelUC
        {
            get
            {
                return deoViewModelUC;
            }

            set
            {
                SetAndNotify(ref deoViewModelUC, value);
            }
        }
        public KorisnikVM TekuciKorisnik
        {
            get
            {
                return tekuciKorisnik;
            }

            set
            {
                SetAndNotify(ref tekuciKorisnik, value);
            }
        }
        #endregion

        #region User kontrole
        public ObservableCollection<string> CmbElementi { get; set; }
        public object TekuciUC
        {
            get
            {
                return tekuciUC;
            }

            set
            {
                SetAndNotify(ref tekuciUC, value);
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            IzvrsiKomande();
            KorisnikViewModelUC = new KorisnikUCViewModel();
            UredjajViewModelUC = new UredjajUCViewModel();
            DeoViewModelUC = new DeloviUCViewModel();
       //TekuciKorisnik = new KorisnikVM();
            //userKontrola();

        }

        #region Komande
        public RelayCommand Otvori { get; set; }
        public RelayCommand PrikazDokumentacije { get; set; }
        public RelayCommand Nazad { get; set; }
        public RelayCommand Napred { get; set; }
        public RelayCommand Unesi { get; set; }
        public RelayCommand Stampaj { get; set; }
        public RelayCommand Sacuvaj { get; set; }
        public RelayCommand UcKorisnikTab { get; set; }
        public RelayCommand UcUredjajTab { get; set; }
        public RelayCommand UcInventarTab { get; set; }
        public RelayCommand Osvezi_Podatke { get; set; }
        #endregion


        private void IzvrsiKomande()
        {
            this.Otvori = new RelayCommand
            (
                delegate (object o)
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Dokument (*.txt)|*.txt| All files (*.*)|*.*";
                    if (dialog.ShowDialog() ?? false)
                    {
                        using (XmlReader reader = XmlReader.Create(dialog.FileName))
                        {
                            //Ide serializer...
                        }
                    }
                }
            );
            this.UcKorisnikTab = new RelayCommand
            (
                delegate(object o)
                {
                    TekuciUC = KorisnikViewModelUC;
                    //KorisnikViewModelUC.OsveziPodatke();
                },
                o => true    
            );
            this.UcUredjajTab = new RelayCommand
            (
                delegate (object o)
                {
                    TekuciUC = UredjajViewModelUC;
                },
                o => true
            );

            this.UcInventarTab = new RelayCommand
            (
                delegate(object o)
                {
                    TekuciUC = DeoViewModelUC;
                },
                o => true    
            );
                  
            this.PrikazDokumentacije = new RelayCommand
            (
                delegate (object o)
                {
                    try
                    {
                        Process proces = new Process();
                        string putanjaDokumenta = AppDomain.CurrentDomain.BaseDirectory + @"Resources\Documentation\Zavrsni_rad.pdf";
                        Uri pdf = new Uri(putanjaDokumenta, UriKind.RelativeOrAbsolute);
                        proces.StartInfo.FileName = pdf.LocalPath;
                        proces.Start();
                        proces.WaitForExit();
                    }
                    catch (Exception)
                    {

                        PrikaziUIPoruku("Dokumentacija ne može da se otvori");
                    }
                }
            );

            this.Sacuvaj = new RelayCommand
            (
                delegate(object o)
                {
                    db.SaveChanges();
                    PrikaziUIPoruku("Podaci su sacuvani");
                },
                o => true
            );

            this.Unesi = new RelayCommand
            (
                delegate (object o)
                {

                },
                o => true
            );

            this.Osvezi_Podatke = new RelayCommand
            (
                delegate (object o)
                {
                    KorisnikViewModelUC.OsveziPodatke();
                    UredjajViewModelUC.OsveziPodatke();
                    DeoViewModelUC.OsveziPodatke();
                },
                o => true
            );
        }

    }

}

