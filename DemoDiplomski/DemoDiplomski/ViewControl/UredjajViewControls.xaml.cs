using DemoDiplomski.ViewModel;
using System.Windows.Controls;

namespace DemoDiplomski.ViewControl
{
    /// <summary>
    /// Interaction logic for UredjajViewControls.xaml
    /// </summary>
    public partial class UredjajViewControls : UserControl
    {
        UredjajUCViewModel uredjajViewModel = new UredjajUCViewModel();

        public UredjajViewControls()
        {
            InitializeComponent();
            this.DataContext = uredjajViewModel;
        }
       
    }
}
