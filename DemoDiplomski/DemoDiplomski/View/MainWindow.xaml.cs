using DemoDiplomski.Properties;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DemoDiplomski.Model;
using DemoDiplomski.ViewModel;
using DemoDiplomski.ViewControl.DijaloziZaUnos;
using System.ComponentModel;
using System.Windows.Data;
using DemoDiplomski.Utility;
using System.Collections;
using System.Collections.Generic;
using DemoDiplomski.Message;
using System.Windows.Media.Animation;
using GalaSoft.MvvmLight.Messaging;
using DemoDiplomski.ViewControl;

namespace DemoDiplomski.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IModalServisUserControl
    {
        TehnoklinikModel db = new TehnoklinikModel();
        MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
        private bool prikaziSakrijToolBar;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mainWindowViewModel;

            //Podesavanja za velicinu prozora i za SolidColorBrus - personalizaciju ekrana moze da ostane unutar cs klase glavnog prozora
            this.Top = Settings.Default.MainWindowTop;
            this.Left = Settings.Default.MainWindowLeft;
            this.Height = Settings.Default.MainWindowHeight;
            this.Width = Settings.Default.MainWindowWidth;

            //mMeni.Foreground = new SolidColorBrush(Settings.Default.DisplayForegroundColor);
            //mMeni.Background = new SolidColorBrush(Settings.Default.DisplayBackgroundColor);

            //tToolBar.Background = new SolidColorBrush(Settings.Default.DisplayBackgroundColor);
            
            tabControl.Foreground = new SolidColorBrush(Settings.Default.DisplayForegroundColor);
            ccEditor.Foreground = new SolidColorBrush(Settings.Default.DisplayForegroundColor);
            tabControl.Background = new SolidColorBrush(Settings.Default.DisplayBackgroundColor);
            ccEditor.Background = new SolidColorBrush(Settings.Default.DisplayBackgroundColor);
            grdMainGrid.Background = new SolidColorBrush(Settings.Default.DisplayBackgroundColor);
            this.prikaziSakrijToolBar = Settings.Default.PrikaziSakrijToolBar;

            Messenger.Default.Register<UIPoruka>(this, (action) => PoslataPoruka(action));
        }

        private void PoslataPoruka(UIPoruka poruka)
        {
            UIPoruka.Opacity = 1;
            UIPoruka.Text = poruka.Poruka;
            Storyboard sb = this.FindResource("FadeEfekatPoruke") as Storyboard;
            sb.Begin();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.MainWindowTop = this.Top;
            Settings.Default.MainWindowLeft = this.Left;
            Settings.Default.MainWindowHeight = this.Height;
            Settings.Default.MainWindowWidth = this.Width;
            Settings.Default.DisplayForegroundColor = (tabControl.Foreground as SolidColorBrush).Color;
            Settings.Default.DisplayForegroundColor = (ccEditor.Foreground as SolidColorBrush).Color;
            Settings.Default.DisplayBackgroundColor = (tabControl.Background as SolidColorBrush).Color;
            Settings.Default.DisplayBackgroundColor = (ccEditor.Background as SolidColorBrush).Color;
            Settings.Default.DisplayBackgroundColor = (grdMainGrid.Background as SolidColorBrush).Color;
            Settings.Default.PrikaziSakrijToolBar = this.prikaziSakrijToolBar;
            Settings.Default.Save();
            base.OnClosing(e);
            db.SaveChanges();
            
        }

        //Upit za brisanje treba smestiti unutar klase VM ServisDekoviVM
        //Brisanje se obavlja unosom sifre unutar polja, brisanje se vrsi samo nad tabelom Delovi
        private void btnBrisanje_Click(object sender, RoutedEventArgs e)
        {
        }
        private void menuAlati_Click(object sender, RoutedEventArgs e)
        {
                OptionDialog oD = new OptionDialog();

                oD.DisplayForegroundColor = (tabControl.Foreground as SolidColorBrush).Color;
                oD.DisplayForegroundColor = (ccEditor.Foreground as SolidColorBrush).Color;
                oD.DisplayBackgroundColor = (tabControl.Background as SolidColorBrush).Color;
                oD.DisplayBackgroundColor = (ccEditor.Background as SolidColorBrush).Color;
                oD.DisplayBackgroundColor = (grdMainGrid.Background as SolidColorBrush).Color;

            bool? podesavanje = oD.ShowDialog();
            if (podesavanje ?? false) //ako podesavanje ima rezultat null onda je ceo izraz false
            {
                grdMainGrid.Background = new SolidColorBrush(oD.DisplayBackgroundColor ?? Colors.White); //Podrazumevajuce boje pozadine i boje slova su bela i crna
                tabControl.Background = new SolidColorBrush(oD.DisplayBackgroundColor ?? Colors.White); //U slucaju da je null, bela i crna je podrazumevajuca boja
                tabControl.Foreground = new SolidColorBrush(oD.DisplayForegroundColor ?? Colors.Black);
                ccEditor.Background = new SolidColorBrush(oD.DisplayBackgroundColor ?? Colors.White);
                ccEditor.Foreground = new SolidColorBrush(oD.DisplayForegroundColor ?? Colors.Black);
                this.prikaziSakrijToolBar = oD.PrikaziSakrijToolBar;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) => 
            GlavniModalServis.ModalServis.OtvoriUC(new DijaloziZaUnosUC(), delegate (bool vratiVrednost) { });


        #region ModalPopUp
        private Stack<NavigacijaHendler> kontrole = new Stack<NavigacijaHendler>();

        public void OtvoriUC(UserControl uc, NavigacijaHendler vratiUC)
        {
            foreach (UIElement element in grdRoditelj.Children)
                element.IsEnabled = false;
            grdRoditelj.Children.Add(uc);

            kontrole.Push(vratiUC);
        }

        public void ZatvoriUC(bool vratiVrednost)
        {
            grdRoditelj.Children.RemoveAt(grdRoditelj.Children.Count - 1);
            UIElement element = grdRoditelj.Children[grdRoditelj.Children.Count - 1];
            element.IsEnabled = true;
            kontrole.Pop()?.Invoke(vratiVrednost);

            //Pozivanje OsveziPodatke() metode za refreshovanje liste
            mainWindowViewModel.KorisnikViewModelUC.OsveziPodatke(); 
            mainWindowViewModel.UredjajViewModelUC.OsveziPodatke();
            mainWindowViewModel.DeoViewModelUC.OsveziPodatke();
        }

        #endregion

        private void DodajKorisnika_Click(object sender, RoutedEventArgs e) => 
            GlavniModalServis.ModalServis.OtvoriUC(new KorisnikUC(), 
                delegate (bool vratiVrednost) 
            {
            });

        private void DodajUredjaj_Click(object sender, RoutedEventArgs e) => 
            GlavniModalServis.ModalServis.OtvoriUC(new UredjajUC(), 
                delegate (bool vratiVrednost) 
            {
            });

        private void DodajDelove_Click(object sender, RoutedEventArgs e) => 
            GlavniModalServis.ModalServis.OtvoriUC(new DeoUC(), 
                delegate (bool vratiVrednost) 
            {
            });

        private void PokreniLoginDialog()
        {
        }



        private void OEditoru_Click(object sender, RoutedEventArgs e)
        {
            AboutView oEditoru = new AboutView();
            oEditoru.Show();

        }

        private void Nalog_Click(object sender, RoutedEventArgs e) =>
            GlavniModalServis.ModalServis.OtvoriUC(new KorisnickiNalogUC(),
                delegate (bool vratiVrednost) 
                {
                });

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AzurirajKorisnika_Click_(object sender, RoutedEventArgs e) =>
            GlavniModalServis.ModalServis.OtvoriUC(new KorisnikUC(), 
                delegate (bool vratiVrednost)
            {
            });

        private void AzurirajUredjaj_Click(object sender, RoutedEventArgs e) =>
            GlavniModalServis.ModalServis.OtvoriUC(new UredjajUC(), 
                delegate (bool vratiVrednost)
            {
            });

        private void LoginDialog_Loaded(object sender, RoutedEventArgs e) =>
            GlavniModalServis.ModalServis.OtvoriUC(new LoginDialog(),
                delegate (bool vratiVrednost)
                {

                });



        #region Navigacija

        private void btnPrethodni_Click(object sender, RoutedEventArgs e)
        {
            if (ccEditor.NavigationService.CanGoBack)
            {
                ccEditor.NavigationService.GoBack();
            }
        }

        private void btnSledeci_Click(object sender, RoutedEventArgs e)
        {
            if (ccEditor.NavigationService.CanGoForward)
            {
                ccEditor.NavigationService.GoForward();
            }
        }

        private void btnPrethodniTab_Click(object sender, RoutedEventArgs e)
        {

            int tabIndex = tabControl.SelectedIndex - 1;
            if (tabIndex < 0)
                tabIndex = tabControl.Items.Count - 1;
            tabControl.SelectedIndex = tabIndex;

        }

        private void btnSledeciTab_Click(object sender, RoutedEventArgs e)
        {
            int tabIndex = tabControl.SelectedIndex + 1;
            if (tabIndex >= tabControl.Items.Count)
                tabIndex = 0;
            tabControl.SelectedIndex = tabIndex;
        }

        #endregion

        private void ZatvaranjeAplikacije_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AzurirajInventar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }


        private void btnStampanje_Click_1(object sender, RoutedEventArgs e)
        {

        }

    }
}
