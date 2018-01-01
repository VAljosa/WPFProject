namespace DemoDiplomski.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Utility;

    [Table("LogKorisnik")]
    public partial class Login_Korisnik : NotifyPropertyObject
    {
        private int idLogKorisnik;
        private string ime;
        private string prezime;
        private string uloga;
        private string korisnickoIme;
        private string lozinka;

        public Login_Korisnik() 
        {
        }

        [Key]
        public int IDLogKorisnik { get { return idLogKorisnik; } set { SetAndNotify(ref idLogKorisnik, value); } }

        [Required]
        [StringLength(20)]
        public string Ime { get { return ime; } set { SetAndNotify(ref ime, value); } }

        [StringLength(50)]
        public string Prezime { get { return prezime; } set { SetAndNotify(ref prezime, value); } }//null

        [StringLength(20)]
        public string Uloga { get { return uloga; } set { SetAndNotify(ref uloga, value); } }

        [Required]
        [StringLength(20)]
        public string KorisnickoIme { get { return korisnickoIme; } set { SetAndNotify(ref korisnickoIme, value); } }

        [Required]
        [StringLength(50)]
        public string Lozinka { get { return lozinka; } set { SetAndNotify(ref lozinka, value); } }
    }
}
