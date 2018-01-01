using DemoDiplomski.Utility;
using DemoDiplomski.View;
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
    /// Interaction logic for DijaloziZaUnosUC.xaml
    /// </summary>
    public partial class DijaloziZaUnosUC : UserControl
    {

        public DijaloziZaUnosUC()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlavniModalServis.ModalServis.ZatvoriUC(false);
        }

        private void Korisnici_Open_Dialog(object sender, RoutedEventArgs e)
        {
            GlavniModalServis.ModalServis.OtvoriUC(new KorisnikUC(), delegate (bool vratiVrednost) { });
        }

        private void Uredjaj_Open_Dialog(object sender, RoutedEventArgs e)
        {
            GlavniModalServis.ModalServis.OtvoriUC(new UredjajUC(), delegate (bool vratiVrednost){ });

        }

        private void Deo_Open_Dialog(object sender, RoutedEventArgs e)
        {
            GlavniModalServis.ModalServis.OtvoriUC(new DeoUC(), delegate (bool vratiVrednost){ });

        }
    }
}
