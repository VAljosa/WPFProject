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
    using System.Text.RegularExpressions;
    using Utility;

    [Table("Korisnici")]
    public partial class Korisnici_Korisnik : NotifyPropertyObject, IDataErrorInfo
    {
        private int idKorisnik;
        private string nazivUstanove;
        private string laboratorija;
        private int pib;
        private string grad;
        private string adresa;
        private int postanskiBroj;
        private string telefon;
        private string drzava;


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Korisnici_Korisnik()
        {
            Servis_Dostavnica = new ObservableCollection<Servis_Dostavnica>();
            Servis_Nalog = new ObservableCollection<Servis_Nalog>();
            Servis_Revers = new ObservableCollection<Servis_Revers>();
            Uredjaj_RedovanServis = new ObservableCollection<Uredjaj_RedovanServis>();
            Servis_Uredjaj = new ObservableCollection<Servis_Uredjaj>();
        }

        [Key]
        public int IDKorisnik { get { return idKorisnik; } set { SetAndNotify(ref idKorisnik, value); } }

        [StringLength(200)]
        public string NazivUstanove { get { return nazivUstanove; } set { SetAndNotify(ref nazivUstanove, value); } }

        [Required]
        [StringLength(200)]
        public string Laboratorija { get { return laboratorija; } set { SetAndNotify(ref laboratorija, value); } } //null

        public int PIB { get { return pib; } set { SetAndNotify(ref pib, value); } }

        [StringLength(50)]
        public string Grad { get { return grad; } set { SetAndNotify(ref grad, value); } }

        [StringLength(200)]
        public string Adresa { get { return adresa; } set { SetAndNotify(ref adresa, value); } }

        public int PostanskiBroj { get { return postanskiBroj; } set { SetAndNotify(ref postanskiBroj, value); } }

        public string Telefon { get { return telefon; } set { SetAndNotify(ref telefon, value); } }//null

        [StringLength(50)]
        public string Drzava { get { return drzava; } set { SetAndNotify(ref drzava, value); } }//null


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Servis_Dostavnica> Servis_Dostavnica { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Servis_Nalog> Servis_Nalog { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Servis_Revers> Servis_Revers { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Uredjaj_RedovanServis> Uredjaj_RedovanServis { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Servis_Uredjaj> Servis_Uredjaj { get; }

       
        
        #region IDataErrorInfo clanovi

        public string Error
        {
            get
            {
                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                return validacijaGreske(columnName);
            }
        }

        #endregion


        #region Validacija

        public bool IsValid
        {
            get
            {
                foreach (string property in validacijaString)
                {
                    if (validacijaGreske(property) != null)
                        return false;
                }
                return true;
            }
        }

        static readonly string[] validacijaString = { "NazivUstanove", "Laboratorija", "PIB", "Grad", "Adresa", "PostanskiBroj"};

        //string regPIB = @"^\d$";
        Regex regExNum = new Regex(@"^\d$");
        Regex regExMix = new Regex(@"^\w+$");

        private string validacijaGreske(string columnName)
        {
            string error = null;
            switch (columnName)
            {
                case "NazivUstanove":
                    if (String.IsNullOrWhiteSpace(NazivUstanove)) {
                        error = "Unesite naziv ustanove!";
                    }
                    break;
                case "PIB":
                    if (PIB.ToString().Length < 9 || regExNum.IsMatch(PIB.ToString())){
                        error = "Neispravan PIB! \n PIB se sastoji od 9 brojeva!";
                    }
                    break;
                case "Grad":
                    if (String.IsNullOrWhiteSpace(Grad)){
                        error = "Unesite ime grada u kome se nalazi ustanova!";
                    }
                    break;
                case "Adresa":
                    if (String.IsNullOrWhiteSpace(Adresa) || regExMix.IsMatch(Adresa))
                    {
                        error = "Unesite adresu!";
                    }
                    break;
                case "PostanskiBroj":
                    if (String.IsNullOrWhiteSpace(PostanskiBroj.ToString()) || regExNum.IsMatch(PostanskiBroj.ToString()))
                    {
                        error = "Unesite poštanski broj!";
                    }
                    break;
            }
            return error;
        }

        //private string ValidacijaNazivaUstanove()
        //{
        //    if (String.IsNullOrWhiteSpace(NazivUstanove))
        //    {
        //        return "Unesite naziv ustanove!";
        //    }
        //    return null;
        //}

        //private string validacijaLaboratorija()
        //{
        //    if (String.IsNullOrWhiteSpace(NazivUstanove))
        //    {
        //        return "Unesite naziv ustanove!";
        //    }
        //    return null;
        //}

        #endregion

    }
}
