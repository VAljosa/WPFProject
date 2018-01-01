using DemoDiplomski.Utility;
using DemoDiplomski.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DemoDiplomski.ViewControl.DijaloziZaUnos
{
    /// <summary>
    /// Interaction logic for DeoUC.xaml
    /// </summary>
    public partial class DeoUC : UserControl
    {
        DeloviUCViewModel deloviViewModel = new DeloviUCViewModel();

        public DeoUC()
        {
            InitializeComponent();
            this.DataContext = deloviViewModel;
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
