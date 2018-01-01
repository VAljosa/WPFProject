namespace DemoDiplomski.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Utility;

    [Table("Nalog")]
    public partial class Servis_Nalog : NotifyPropertyObject
    {
        private int idNalog;
        private string brRadNalog;
        private DateTime datum;
        private int? idDelovi;
        private int idUredjaj;
        private int idKorisnik;

        public Servis_Nalog() 
        {
        }

        [Key]
        public int IDNalog { get { return idNalog; } set { SetAndNotify(ref idNalog, value); } }

        [Required]
        [StringLength(10)]
        public string BrRadNalog { get { return brRadNalog; } set { SetAndNotify(ref brRadNalog, value); } }

        [Column(TypeName = "date")]
        public DateTime Datum { get { return datum; } set { SetAndNotify(ref datum, value); } }

        public int? IDDelovi { get { return idDelovi; } set { SetAndNotify(ref idDelovi, value); } }

        public int IDUredjaj { get { return idUredjaj; } set { SetAndNotify(ref idUredjaj, value); } }

        public int IDKorisnik { get { return idKorisnik; } set { SetAndNotify(ref idKorisnik, value); } }




        public virtual Korisnici_Korisnik Korisnici_Korisnik { get; set; }

        public virtual Servis_Delovi Servis_Delovi { get; set; }

        public virtual Servis_Uredjaj Servis_Uredjaj { get; set; }
    }
}
