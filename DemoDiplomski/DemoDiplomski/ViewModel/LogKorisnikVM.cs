using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using DemoDiplomski.View;

namespace DemoDiplomski.ViewModel
{
    public class LogKorisnikVM : ViewModelObject<LogKorisnik>, IDataErrorInfo
    {

        private LogKorisnik logKorisnik;

        public LogKorisnik LogKorisnik
        {
            get
            {
                return logKorisnik;
            }
        }

        public LogKorisnikVM(LogKorisnik model)
             : base(model)
        {
            this.logKorisnik = model;           
        }



        #region IDataErrorInfo clanovi

        public string Error
        {
            get
            {
                return null;
            }
        }
        

        public string this[string columnName]
        {
            get
            {
                return validacijaLogGreske(columnName);
            }
        }


        #endregion

        #region Validacija

        static readonly string[] validacijaLogString = { "Ime", "Uloga", "KorisnickoIme", "Lozinka"};

        Regex regExMix = new Regex(@"^\w+$");
        Regex regExPass = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");

        public bool IsValid
        {
            get
            {
                foreach (string property in validacijaLogString)
                {
                    if (validacijaLogGreske(property) != null)
                        return false;
                }
                return true;
            }
        }


        private string validacijaLogGreske(string columnName)
        {
            string error = null;
            switch (columnName)
            {
                case "Ime":
                    if (String.IsNullOrWhiteSpace(Model.Ime))
                    {
                        error = "Unesite ispravno ime!";
                    }
                    break;          
                case "KorisnkickoIme":
                    if (regExMix.IsMatch(Model.KorisnickoIme))
                    {
                        error = "Unesite korisničko ime!";
                    }
                    break;
                case "Lozinka":
                    if (regExPass.IsMatch(Model.Lozinka))
                    {
                        error = "Lozinka nije ispravna! \n Unesite minimum 8 karaktera!";
                    }
                    break;
            }
            return error;
        }

        #endregion



        public void saveChanges()
        {
            //Cuvaju se promene unutar modela, ili Data izvora
        }
    }
}
