using DemoDiplomski.Message;
using DemoDiplomski.Utility;
using DemoDiplomski.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoDiplomski.ViewControl.DijaloziZaUnos
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : UserControl
    {
        //private UIElement roditelj; za enablovanje, ne gasenje i zatvaranje roditeljskog prozora
        public LoginDialog()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\Tehnoklinik.mdf; Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(connection);
            string loginQuery = "Select * From LogKorisnik where KorisnickoIme = '" + tbKorisnickoIme.Text.Trim() + "' and Lozinka = '" + tbLozinka.Password.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(loginQuery, con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                GlavniModalServis.ModalServis.ZatvoriUC(true);
            }
            else
            {
                MessageBox.Show("Uneto korisničko ime ili lozinka nije ispravno","Greška", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            GlavniModalServis.ModalServis.ZatvoriUC(false);
            Application.Current.Shutdown();
        }

        private void PoslataPoruka(UIPoruka poruka)
        {
            UIPoruka.Opacity = 1;
            UIPoruka.Text = poruka.Poruka;
            Storyboard sb = this.FindResource("FadeEfekatPoruke") as Storyboard;
            sb.Begin();
        }

    }
}
