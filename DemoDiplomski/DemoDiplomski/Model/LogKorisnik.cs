namespace DemoDiplomski.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    [Table("LogKorisnik")]
    public partial class LogKorisnik : IDataErrorInfo, INotifyPropertyChanged
    {
        private int idLogKorisnik;
        private string ime;
        private string prezime;
        private string uloga;
        private string korisnickoIme;
        private string lozinka;

        [Key]
        public int IDLogKorisnik { get { return idLogKorisnik; } set { SetAndNotify(ref idLogKorisnik, value); } }

        [Required]
        [StringLength(20)]
        public string Ime { get { return ime; } set { SetAndNotify(ref ime, value); } }

        [StringLength(50)]
        public string Prezime { get { return prezime; } set { SetAndNotify(ref prezime, value); } }

        
        [StringLength(20)]
        public string Uloga { get { return uloga; } set { SetAndNotify(ref uloga, value); } }

        [Required]
        [StringLength(20)]
        public string KorisnickoIme { get { return korisnickoIme; } set { SetAndNotify(ref korisnickoIme, value); } }

        [Required]
        [StringLength(50)]
        public string Lozinka { get { return lozinka; } set { SetAndNotify(ref lozinka, value); } }



        #region IDataErrorInfo clanovi
        public string Error => null;

        public string this[string imeSvojstva] => DohvatiValidacijuError(imeSvojstva);

        #endregion

        #region Validacija

        static readonly string[] validacijaLogString = { "Ime", "KorisnickoIme", "Lozinka" };
        private string lozinkaPonovo;
        protected string LozinkaPonovo { get { return lozinkaPonovo; } set { SetAndNotify(ref lozinkaPonovo, value); } }

        private string DohvatiValidacijuError(string imeSvojstva)
        {
            string error = string.Empty;
            switch (imeSvojstva)
            {
                case "Ime":
                    if (String.IsNullOrWhiteSpace(Ime))
                    {
                        error = "Unesite ime";
                    }
                    break;
                case "KorisnickoIme":
                    if (String.IsNullOrWhiteSpace(KorisnickoIme))
                    {
                        error = "Unesite korisničko ime";
                    }
                    break;
                case "Lozinka":
                    if (String.IsNullOrWhiteSpace(Lozinka))
                    {
                        error = "Lozinka nije ispravna! \n Unesite minimum 8 karaktera";
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
