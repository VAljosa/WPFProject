namespace DemoDiplomski.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Utility;

    [Table("Dostavnica")]
    public partial class Servis_Dostavnica : NotifyPropertyObject
    {
        private int idDostavnica;
        private DateTime datum;
        private string brDostavnica;
        private int idKorisnik;
        private int idUredjaj;

        public Servis_Dostavnica() 
        {
        }

        [Key]
        public int IDDostavnica { get { return idDostavnica; } set { SetAndNotify(ref idDostavnica, value); } }

        [Column(TypeName = "date")]
        public DateTime Datum { get { return datum; } set { SetAndNotify(ref datum, value); } }

        [Required]
        [StringLength(10)]
        public string BrDostavnica { get { return brDostavnica; } set { SetAndNotify(ref brDostavnica, value); } }

        public int IDKoriscnik { get { return idKorisnik; } set { SetAndNotify(ref idKorisnik, value); } }

        public int IDUredjaj { get { return idUredjaj; } set { SetAndNotify(ref idUredjaj, value); } }

        public virtual Korisnici_Korisnik Korisnici_Korisnik { get; set; }

        public virtual Servis_Uredjaj Servis_Uredjaj { get; set; }
    }
}
