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

    [Table("Uredjaj")]
    public partial class Uredjaj : IDataErrorInfo, INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uredjaj()
        {
            Dostavnice = new ObservableCollection<Dostavnica>();
            Nalozi = new ObservableCollection<Nalog>();
            RedovniServisi = new ObservableCollection<RedovanServis>();
            Reversi = new ObservableCollection<Revers>();
            Delovi = new ObservableCollection<Deo>();
            VandredniServisi = new ObservableCollection<VandredniServis>();
        }

        private int idUredjaj;
        private string s_N;
        private string tip;
        private string nazivUredjaja;
        private string detalji;

        [Key]
        public int IDUredjaj { get { return idUredjaj; } set { SetAndNotify(ref idUredjaj, value); } }

        [Column("S/N")]
        [Required]
        [StringLength(10)]
        public string S_N { get { return s_N; } set { SetAndNotify(ref s_N, value); } }

        [StringLength(50)]
        public string Tip { get { return tip; } set { SetAndNotify(ref tip, value); } }

        [StringLength(20)]
        [NotMapped]
        public string NazivUredjaja { get => nazivUredjaja; set => SetAndNotify(ref nazivUredjaja, value); }

        public string Detalji { get { return detalji; } set { SetAndNotify(ref detalji, value); } }




        public int? IDKorisnik { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Dostavnica> Dostavnice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Nalog> Nalozi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<RedovanServis> RedovniServisi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Revers> Reversi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Deo> Delovi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<VandredniServis> VandredniServisi { get; set; }

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

        static readonly string[] SvojsvaZaValidaciju = { "S_N", "Tip" };


        private string DohvatiValidacijuError(string imeSvojstva)
        {
            string error = null;

            switch (imeSvojstva)
            {
                case "S_N":
                    if (String.IsNullOrWhiteSpace(S_N))
                    {
                        error = "Serijski broj je obavezno polje";
                    }
                    break;
                case "Tip":
                    if (String.IsNullOrWhiteSpace(Tip))
                    {
                        error = "Tip uređaja je obavezno polje";
                    }
                    break;
            }
            return error;
        }

        //public bool IsValid
        //{
        //    get
        //    {
        //        foreach (string svojstvo in SvojsvaZaValidaciju)
        //        {
        //            if (DohvatiValidacijuError(svojstvo) != null)
        //                return false;
        //        }
        //        return true;
        //    }
        //}

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
