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

    [Table("Dostavnica")]
    public partial class Dostavnica : INotifyPropertyChanged
    {
        private int idDostavnica;
        private DateTime datum;
        private string brDostavnice;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dostavnica()
        {
            Uredjaji = new ObservableCollection<Uredjaj>();
        }


        [Key]
        public int IDDostavnica { get { return idDostavnica; } set { SetAndNotify(ref idDostavnica, value); } }

        [Column(TypeName = "date")]
        public DateTime Datum { get { return datum; } set { SetAndNotify(ref datum, value); } }

        [Required]
        [StringLength(10)]
        public string BrDostavnica { get { return brDostavnice; } set { SetAndNotify(ref brDostavnice, value); } }




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
