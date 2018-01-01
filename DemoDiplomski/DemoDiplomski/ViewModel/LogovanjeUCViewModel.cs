using DemoDiplomski.Utility;
using DemoDiplomski.ViewModel.ModelVM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDiplomski.ViewModel
{
    public class LogovanjeUCViewModel : CrudVMBase
    {
        private KorisnickiNalogVM selektovaniKorisnik;

        public KorisnickiNalogVM SelektovaniKorisnik { get => selektovaniKorisnik; set => SetAndNotify(ref selektovaniKorisnik, value); }

        public LogovanjeUCViewModel()
        {
            InicijalizovaneKomande();
        }

        public RelayCommand PrijaviSe { get; set; }

        private void InicijalizovaneKomande()
        {
            this.PrijaviSe = new RelayCommand
            (
                delegate(object o)
                {
                    Prijavljivanje();
                },
                o => true
            );
        }

        private void Prijavljivanje()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", @"D:\DiplomskiMaterijal\DemoDiplomskiCodeFirst\DemoDiplomski\DemoDiplomski\bin\Debug");
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\Tehnoklinik.mdf; Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(connection);
            string loginQuery = "Select * From LogKorisnik where KorisnickoIme = '" + SelektovaniKorisnik.Model.KorisnickoIme.Trim() + "' and Lozinka = '" + SelektovaniKorisnik.Model.Lozinka.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(loginQuery, con);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                GlavniModalServis.ModalServis.ZatvoriUC(true);
            }
            else
            {
                PrikaziUIPoruku("Uneto korisničko ime ili lozinka nije ispravno");
            }

        }
    }
}
