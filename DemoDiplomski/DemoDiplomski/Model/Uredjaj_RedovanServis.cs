namespace DemoDiplomski.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Utility;

    [Table("RedovanServis")]
    public partial class Uredjaj_RedovanServis : NotifyPropertyObject
    {
        private int idRedovanServis;
        private DateTime redovanServis;
        private int idUredjaj;
        private int idKorisnik;

        public Uredjaj_RedovanServis() 
        {
        }

        [Key]
        public int IDRedovanServis { get { return idRedovanServis; } set { SetAndNotify(ref idRedovanServis, value); } }

        [Column(TypeName = "date")]
        public DateTime RedovanServis { get { return redovanServis; } set { SetAndNotify(ref redovanServis, value); } }

        public int IDUredjaj { get { return idUredjaj; } set { SetAndNotify(ref idUredjaj, value); } }

        public int IDKorisnk { get { return idKorisnik; } set { SetAndNotify(ref idKorisnik, value); } }

        public virtual Korisnici_Korisnik Korisnici_Korisnik { get; set; }

        public virtual Servis_Uredjaj Servis_Uredjaj { get; set; }
    }
}
