using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace DemoDiplomski.ViewModel
{
    public class KorisniciVM : ViewModelObject<Korisnici_Korisnik>, IDataErrorInfo
    {
       
        private ObservableCollection<Korisnici_Korisnik> korisnici = new ObservableCollection<Korisnici_Korisnik>();


        public ObservableCollection<Korisnici_Korisnik> Korisnici
        {
            get
            {
                return korisnici;
            }
        }


        //U trenutnu kreranja KorisniciKorisnikVM-a , KorisniciKorisnikVM je svestan svoga Korisnici_Korisnik
        public KorisniciVM(Korisnici_Korisnik model) 
            : base(model)
        {
        }



        #region Validacija clanovi
        public string this[string columnName]
        {
            get
            {
                return ValidacijaGreske(columnName);
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        } 
        #endregion

        #region ValidacijaGreske
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidacioniProperty)
                {
                    if (ValidacijaGreske(property) != null)
                        return false;

                }
                return true;
            }
        }

        public readonly string[] ValidacioniProperty = { "NazivUstanove", "Laboratorija", "PIB", "Grad" };

        string ValidacijaGreske(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "NazivUstanove":
                    if (String.IsNullOrWhiteSpace(Model.NazivUstanove))
                        error = "Ovo je obavezno polje";
                    break;
                case "Laboratorija":
                    if (String.IsNullOrWhiteSpace(Model.Laboratorija))
                        error = "Ovo je obavezno polje";
                    break;
                case "PIB":
                    if (Model.PIB == 9)
                        error = "Ovo je obavezno polje";
                    break;
                case "Grad":
                    if (String.IsNullOrWhiteSpace(Model.Grad))
                        error = "Ovo je obavezno polje";
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
