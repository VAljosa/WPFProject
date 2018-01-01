using DemoDiplomski.Message;
using DemoDiplomski.Utility;
using DemoDiplomski.View;
using DemoDiplomski.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace DemoDiplomski.ViewControl.DijaloziZaUnos
{
    /// <summary>
    /// Interaction logic for KorisnikUC.xaml
    /// </summary>
    public partial class KorisnikUC : UserControl
    {
        KorisnikUCViewModel korisnikViewModelUC = new KorisnikUCViewModel();

        public KorisnikUC()
        {
            InitializeComponent();
            DataContext = korisnikViewModelUC;

            Messenger.Default.Register<UIPoruka>(this, (action) => PoslataPoruka(action));

        }

        private void PoslataPoruka(UIPoruka poruka)
        {
            UIPoruka.Opacity = 1;
            UIPoruka.Text = poruka.Poruka;
            Storyboard sb = this.FindResource("FadeEfekatPoruke") as Storyboard;
            sb.Begin();
        }


        //public void Roditelj(UIElement roditelj) //Roditelj je UIElement i roditelj se kreira kada se otvori prozor
        //{
        //    this.roditelj = roditelj;
        //}

        //private UIElement roditelj;
        //private bool sakriDialog = false;
        //private bool rezultat = false;

        //public bool PrikaziDialogHendler()
        //{
        //    Visibility = Visibility.Visible;//Visibility.Visible, prikazuje se kontrola
        //    roditelj.IsEnabled = false;//prilikom prikazivanja usercontrole, roditelj.IsEnabled je false
        //    while (!sakriDialog)
        //    {
        //        if (this.Dispatcher.HasShutdownStarted || this.Dispatcher.HasShutdownFinished)
        //        {
        //            break;
        //        }
        //        this.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
        //        Thread.Sleep(20);
        //    }

        //    return rezultat;
        //}

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            tbNazivUstanove.Clear();
            tbLaboratorija.Clear();
            tbPib.Clear();
            tbAdresa.Clear();
            tbTelefon.Clear();
            tbPostansiBroj.Clear();
            tbGrad.Clear();
            tbDrzava.Clear();
            GlavniModalServis.ModalServis.ZatvoriUC(false);
        }


        private void SacuvajIIzadji_Click(object sender, RoutedEventArgs e)
        {
            GlavniModalServis.ModalServis.ZatvoriUC(true);
        }
    }
}
