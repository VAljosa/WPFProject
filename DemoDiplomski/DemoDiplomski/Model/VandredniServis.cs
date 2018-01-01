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

    public partial class VandredniServis : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VandredniServis()
        {
            Uredjaji = new ObservableCollection<Uredjaj>();
        }

        private int idVandredniServis;
        private DateTime datumServisa;
        private string opisPosla;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDVandredniServis { get { return idVandredniServis; } set { SetAndNotify(ref idVandredniServis, value); } }

        [Column(TypeName = "date")]
        public DateTime DatumServisa { get { return datumServisa; } set { SetAndNotify(ref datumServisa, value); } }

        public string OpisPosla { get { return opisPosla; } set { SetAndNotify(ref opisPosla, value); } }




        public int IDNalog { get; set; }

        public virtual Nalog Nalog { get; set; }

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
