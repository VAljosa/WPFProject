namespace DemoDiplomski.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    [Table("Korisnik")]
    public partial class Korisnik : IDataErrorInfo, INotifyPropertyChanged
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korisnik()
        {
            Dostavnice = new ObservableCollection<Dostavnica>();
            Nalozi = new ObservableCollection<Nalog>();
            Reversi = new ObservableCollection<Revers>();
            Uredjaji = new ObservableCollection<Uredjaj>();
        }

        private int idKorisnik;
        private string nazivUstanove;
        private string laboratorija;
        private int pib;
        private string grad;
        private string adresa;
        private int postanskiBroj;
        private string telefon;
        private string drzava;

        [Key]
        public int IDKorisnik { get { return idKorisnik; } set { SetAndNotify(ref idKorisnik, value); } }

        [Required(ErrorMessage = "Polje Naziv ustanove ne može da bude prazno")]
        [StringLength(200)]
        public string NazivUstanove { get { return nazivUstanove; } set { SetAndNotify(ref nazivUstanove, value); } }

        [StringLength(200)]
        public string Laboratorija { get { return laboratorija; } set { SetAndNotify(ref laboratorija, value); } }

        public int PIB { get { return pib; } set { SetAndNotify(ref pib, value); } }

        [Required(ErrorMessage = "Polje Grad ne može da bude prazno")]
        [StringLength(50)]
        public string Grad { get { return grad; } set { SetAndNotify(ref grad, value); } }

        [Required(ErrorMessage = "Polje Adresa ne može da bude prazno")]
        [StringLength(200)]
        public string Adresa { get { return adresa; } set { SetAndNotify(ref adresa, value); } }


        public int PostanskiBroj { get { return postanskiBroj; } set { SetAndNotify(ref postanskiBroj, value); } }

        public string Telefon { get { return telefon; } set { SetAndNotify(ref telefon, value); } }

        [StringLength(50)]
        public string Drzava { get { return drzava; } set { SetAndNotify(ref drzava, value); } }




        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Dostavnica> Dostavnice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Nalog> Nalozi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Revers> Reversi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Uredjaj> Uredjaji { get; set; }

        #region IDataErrorInfo
        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string imeSvojstva]
        {
            get
            {
                return DohvatiValidacijuError(imeSvojstva);
            }
        }
        #endregion

        #region Validacija

        static readonly string[] SvojsvaZaValidaciju = { "NazivUstanove", "PIB", "Grad", "Adresa", "PostanskiBroj", "Telefon", "Drzava" };


        private string DohvatiValidacijuError(string imeSvojstva)
        {
            string error = string.Empty;
            string postanskiBroj = PostanskiBroj.ToString();
            string pib = PIB.ToString();
            Regex regNumeric = new Regex(@"^[0-9]+$");

            switch (imeSvojstva)
            {
                case "NazivUstanove":
                    if (String.IsNullOrEmpty(NazivUstanove))
                    {
                        error = "Ime ustanove je obavezan podatak";
                    }
                    break;
                case "PIB":
                    if (pib.Length == 0)
                        error = "PIB broj je obavezan podatak";
                    if (pib.Length < 9)
                        error = "PIB ima minimum 9 brojeva";
                    break;
                case "Grad":
                    if (String.IsNullOrEmpty(Grad))
                    {
                        error = "Grad  je obavezan podatak";
                    }
                    break;
                case "Adresa":
                    if (String.IsNullOrEmpty(Adresa))
                    {
                        error = "Adresa je obavezan podatak";
                    }
                    break;
                case "PostanskiBroj":
                    if (PostanskiBroj == 0)
                    {
                        error = "Broj pošte je obavezan podatak";
                    }
                    break;
                case "Telefon":
                    if (String.IsNullOrEmpty(Telefon))
                    {
                        error = "Telefon je obavezan podatak";
                    }
                    break;
                case "Drzava":
                    if (String.IsNullOrEmpty(Drzava))
                    {
                        error = "Država je obavezan podatak";
                    }
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

    }
}
