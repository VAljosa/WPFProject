namespace DemoDiplomski.Model
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Utility;

    [Table("Delovi")]
    public partial class Servis_Delovi : NotifyPropertyObject
    {
        private int idDelovi;
        private string s_N;
        private string naziv;
        private int? kolicina;
        private bool naStanju;
        private decimal? cena;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servis_Delovi()
        {
            Servis_Nalog = new ObservableCollection<Servis_Nalog>();
            Servis_Uredjaj = new ObservableCollection<Servis_Uredjaj>();
        }

        [Key]
        public int IDDelovi { get { return idDelovi; } set { SetAndNotify(ref idDelovi, value); } }

        [Column("S/N")]
        [Required]
        [StringLength(10)]
        public string S_N { get { return s_N; } set { SetAndNotify(ref s_N, value); } }

        [StringLength(50)]
        public string Naziv { get { return naziv; } set { SetAndNotify(ref naziv, value); } }

        public int? Kolicina { get { return kolicina; } set { SetAndNotify(ref kolicina, value); } }

        public bool NaStanju { get { return naStanju; } set { SetAndNotify(ref naStanju, value); } }

        [Column(TypeName = "money")]
        public decimal? Cena { get { return cena; } set { SetAndNotify(ref cena, value); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Servis_Nalog> Servis_Nalog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Servis_Uredjaj> Servis_Uredjaj { get; set; }
    }
}
