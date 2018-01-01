namespace DemoDiplomski.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Utility;

    [Table("Revers")]
    public partial class Servis_Revers : NotifyPropertyObject
    {
        private int idRevers;
        private DateTime datum;
        private string brRevers;
        private int idKorisnik;
        private int idUredjaj;

        public Servis_Revers() 
        {
        }

        [Key]
        public int IDRevers { get { return idRevers; } set { SetAndNotify(ref idRevers, value); } }

        [Column(TypeName = "date")]
        public DateTime Datum { get { return datum; } set { SetAndNotify(ref datum, value); } }

        [Required]
        [StringLength(10)]
        public string BrRevers { get { return brRevers; } set { SetAndNotify(ref brRevers, value); } }

        public int IDKorisnik { get { return idKorisnik; } set { SetAndNotify(ref idKorisnik, value); } }

        public int IDUredjaj { get { return idUredjaj; } set { SetAndNotify(ref idUredjaj, value); } }

        public virtual Korisnici_Korisnik Korisnici_Korisnik { get; set; }

        public virtual Servis_Uredjaj Servis_Uredjaj { get; set; }
    }
}
