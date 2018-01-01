using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for AboutDialog.xaml
    /// </summary>
    public partial class AboutView : Window
    {
        public AboutView()
        {
            InitializeComponent();
            Assembly assembly = Assembly.GetEntryAssembly();//Assembly je klasa koja opisuje sama sebe, moze da se koristi za vise verzija i vise svrha
            AssemblyTitleAttribute titleAttr = assembly.GetCustomAttribute(typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute;
            AssemblyFileVersionAttribute versionAttr = assembly.GetCustomAttribute(typeof(AssemblyFileVersionAttribute)) as AssemblyFileVersionAttribute;
            AssemblyCopyrightAttribute copyrightAttr = assembly.GetCustomAttribute(typeof(AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute;

            txtAppName.Text = titleAttr.Title;
            txtVersion.Text = versionAttr.Version;
            txtCopyright.Text = copyrightAttr.Copyright;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
