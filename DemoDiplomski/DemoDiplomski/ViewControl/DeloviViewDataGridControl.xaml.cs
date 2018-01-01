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

namespace DemoDiplomski.ViewControl
{
    /// <summary>
    /// Interaction logic for DeloviViewDataGridControl.xaml
    /// </summary>
    public partial class DeloviViewDataGridControl : UserControl
    {
        DeloviUCViewModel deloviViewModel = new DeloviUCViewModel();

        public DeloviViewDataGridControl()
        {
            InitializeComponent();
            this.DataContext = deloviViewModel;
        }
    }
}
