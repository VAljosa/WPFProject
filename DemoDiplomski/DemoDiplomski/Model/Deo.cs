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

    [Table("Deo")]
    public partial class Deo : IDataErrorInfo, INotifyPropertyChanged
    {
        private int idDeo;
        private string k_Broj;
        private string naziv;
        private int? kolicina;
        private bool naStanju;
        private decimal? cena;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Deo()
        {
            Nalozi = new ObservableCollection<Nalog>();
            Uredjaji = new ObservableCollection<Uredjaj>();
        }

        [Key]
        public int IDDeo { get { return idDeo; } set { SetAndNotify(ref idDeo, value); } }

        [Required]
        [StringLength(10)]
        public string K_Broj { get { return k_Broj; } set { SetAndNotify(ref k_Broj, value); } }

        [Required]
        [StringLength(50)]
        public string Naziv { get { return naziv; } set { SetAndNotify(ref naziv, value); } }

        public int? Kolicina { get { return kolicina; } set { SetAndNotify(ref kolicina, value); } }

        public bool NaStanju { get { return naStanju; } set { SetAndNotify(ref naStanju, value); } }

        [Column(TypeName = "money")]
        public decimal? Cena { get { return cena; } set { SetAndNotify(ref cena, value); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Nalog> Nalozi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Uredjaj> Uredjaji { get; set; }

        #region IDataErrorInfo clanovi
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

        static readonly string[] SvojstvaZaValidaciju = { "K_Broj", "Naziv", "Kolicina", "NaStanju", "Cena" };

        private string DohvatiValidacijuError(string imeSvojstva)
        {
            string error = null;

            switch (imeSvojstva)
            {
                case "K_Broj":
                    if (String.IsNullOrEmpty(K_Broj))
                    {
                        error = "Kataloški broj je obavezan podatak";
                    }
                    break;
                case "Naziv":
                    if (String.IsNullOrEmpty(Naziv))
                    {
                        error = "Naziv delova je obavezan podatak";
                    }
                    break;
                case "Kolicina":
                    if(Kolicina == 0)
                    {
                        error = "Unesite broj raspolozivih delova";
                    }
                    break;
                case "NaStanju":
                    if(NaStanju == false)
                    {
                        error = "Deo nije na stanju";
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
