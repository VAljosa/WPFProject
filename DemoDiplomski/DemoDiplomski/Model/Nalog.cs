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

    [Table("Nalog")]
    public partial class Nalog : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nalog()
        {
            RedovniServisi = new ObservableCollection<RedovanServis>();
            VandredniServisi = new ObservableCollection<VandredniServis>();
            Delovi = new ObservableCollection<Deo>();
            Uredjaji = new ObservableCollection<Uredjaj>();
        }

        private int idNalog;
        private string brRadNalog;
        private string komentar;
        private DateTime datum;

        [Key]
        public int IDNalog { get { return idNalog; } set { SetAndNotify(ref idNalog, value); } }

        [Required]
        [StringLength(10)]
        public string BrRadNalog { get { return brRadNalog; } set { SetAndNotify(ref brRadNalog, value); } }

        public string Komentar { get { return komentar; } set { SetAndNotify(ref komentar, value); } }

        [Column(TypeName = "date")]
        public DateTime Datum { get { return datum; } set { SetAndNotify(ref datum, value); } }




        public int IDKorisnik { get; set; }

        public virtual Korisnik Korisnik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<RedovanServis> RedovniServisi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<VandredniServis> VandredniServisi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Deo> Delovi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Uredjaj> Uredjaji { get; set; }

        
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
