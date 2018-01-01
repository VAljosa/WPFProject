using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace DemoDiplomski.ViewModel
{
    public class KorisnikVM : IViewModel<Korisnik>, IDataErrorInfo
    {
        private Korisnik korisnik;
        public CollectionView KorisniciView { get; private set; }
        private ObservableCollection<Korisnik> korisnici;

        public ObservableCollection<Korisnik> Korisnici
        {
            get
            {
                return korisnici;
            }

            set
            {
                SetAndNotify(ref korisnici, value);
            }
        }

        public Korisnik Model
        {
            get
            {
                return korisnik;
            }
            set
            {
                SetAndNotify(ref korisnik, value);
            }
        }

        public KorisnikVM()
        {
            Model = new Korisnik();
        }
      

        //Validacija se smesta unutar ViewModel-a, a ne u Model

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


        #region PropertyChangedImpl
        protected void SetAndNotify<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                NotifyPropertyChanged(propertyName);
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        public void saveChanges()
        {
            //Cuvaju se promene unutar modela, ili Data izvora
        }

    }
}
