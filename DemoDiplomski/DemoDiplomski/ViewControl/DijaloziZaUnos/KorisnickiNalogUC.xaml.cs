using DemoDiplomski.Utility;
using DemoDiplomski.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace DemoDiplomski.ViewControl.DijaloziZaUnos
{
    /// <summary>
    /// Interaction logic for KorisnickiNalog.xaml
    /// </summary>
    public partial class KorisnickiNalogUC : UserControl
    {
        private KorisnickiNalogUCViewModel korisnickiNalogUCViewModel = new KorisnickiNalogUCViewModel();

        public KorisnickiNalogUC()
        {
            InitializeComponent();
            this.DataContext = korisnickiNalogUCViewModel;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            GlavniModalServis.ModalServis.ZatvoriUC(false);
        }

    }
}
