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

    public partial class Revers : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Revers()
        {
            Uredjaji = new ObservableCollection<Uredjaj>();
        }

        private int idRevers;
        private DateTime datum;
        private string brRevers;

        [Key]
        public int IDRevers { get { return idRevers; } set { SetAndNotify(ref idRevers, value); } }

        [Column(TypeName = "date")]
        public DateTime Datum { get { return datum; } set { SetAndNotify(ref datum, value); } }

        [Required]
        [StringLength(10)]
        public string BrRevers { get { return brRevers; } set { SetAndNotify(ref brRevers, value); } }





        public int IDKorisnik { get; set; }

        public virtual Korisnik Korisnik { get; set; }

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
