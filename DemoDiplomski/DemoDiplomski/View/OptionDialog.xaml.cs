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
using System.Windows.Shapes;

namespace DemoDiplomski.View
{
    /// <summary>
    /// Interaction logic for OptionDialog.xaml
    /// </summary>
    public partial class OptionDialog : Window
    {
        public OptionDialog()
        {
            InitializeComponent();
        }

        public bool PrikaziSakrijToolBar
        {
            get { return chbToolBar.IsChecked ?? false; }
            set { chbToolBar.IsChecked = value; }
        }

        public Color? DisplayForegroundColor 
        {
            get { return clpDisplayForegroundColor.SelectedColor; }
            set { clpDisplayForegroundColor.SelectedColor = value; } 
        }

        public Color? DisplayBackgroundColor 
        {
            get { return clpDisplayBackgroundColor.SelectedColor; }
            set { clpDisplayBackgroundColor.SelectedColor = value; } 
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
