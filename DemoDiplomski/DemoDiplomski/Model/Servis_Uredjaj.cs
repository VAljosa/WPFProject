namespace DemoDiplomski.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Utility;

    [Table("Uredjaj")]
    public partial class Servis_Uredjaj : NotifyPropertyObject
    {
        private int idUredjaj;
        private string s_N;
        private string tip;
        private string detalji;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servis_Uredjaj()
        {
            Servis_Dostavnica = new ObservableCollection<Servis_Dostavnica>();
            Servis_Nalog = new ObservableCollection<Servis_Nalog>();
            Servis_Revers = new ObservableCollection<Servis_Revers>();
            Uredjaj_RedovanServis = new ObservableCollection<Uredjaj_RedovanServis>();
            Servis_Delovi = new ObservableCollection<Servis_Delovi>();
            Korisnici_Korisnik = new ObservableCollection<Korisnici_Korisnik>();
        }

        [Key]
        public int IDUredjaj { get { return idUredjaj; } set { SetAndNotify(ref idUredjaj, value); } }

        [Column("S/N")]
        [Required]
        [StringLength(10)]
        public string S_N { get { return s_N; } set { SetAndNotify(ref s_N, value); } }

        [StringLength(50)]
        public string Tip { get { return tip; } set { SetAndNotify(ref tip, value); } }

        public string Detalji { get { return detalji; } set { SetAndNotify(ref detalji, value); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Servis_Dostavnica> Servis_Dostavnica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Servis_Nalog> Servis_Nalog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Servis_Revers> Servis_Revers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Uredjaj_RedovanServis> Uredjaj_RedovanServis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Servis_Delovi> Servis_Delovi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Korisnici_Korisnik> Korisnici_Korisnik { get; set; }
    }
}
