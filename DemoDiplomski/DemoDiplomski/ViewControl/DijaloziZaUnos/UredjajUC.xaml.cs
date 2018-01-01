using DemoDiplomski.Utility;
using DemoDiplomski.ViewModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace DemoDiplomski.ViewControl.DijaloziZaUnos
{
    /// <summary>
    /// Interaction logic for UredjajUC.xaml
    /// </summary>
    public partial class UredjajUC : UserControl
    {
        UredjajUCViewModel uredjajViewModel = new UredjajUCViewModel();

        public UredjajUC()
        {
            InitializeComponent();
            this.DataContext = uredjajViewModel;
        }

        //public void Roditelj(UIElement roditelj)
        //{
        //    this.roditelj = roditelj;
        //}

        //private UIElement roditelj;
        //private bool sakriDialog = false;
        //private bool rezultat = false;

        //public bool PrikaziDialogHendler()
        //{
        //    Visibility = Visibility.Visible;
        //    roditelj.IsEnabled = false;
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

        //private void SakrijDialog()
        //{
        //    sakriDialog = true;
        //    Visibility = Visibility.Hidden;
        //    roditelj.IsEnabled = true;
        //}


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            GlavniModalServis.ModalServis.ZatvoriUC(false);
        }

        private void SacuvajIIzadji_Click(object sender, RoutedEventArgs e)
        {
            GlavniModalServis.ModalServis.ZatvoriUC(true);
        }
    }
}
