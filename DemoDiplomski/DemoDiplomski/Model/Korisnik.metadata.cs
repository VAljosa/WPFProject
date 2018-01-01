using DemoDiplomski.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDiplomski.Model
{
    [MetadataType(typeof(KorisnikMetadata))]
    public partial class Korisnik : EntityErrorLogic
    {
        //MetaSetUp() metoda
        public void MetaDataSet()
        {
            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Korisnik),
                                                                  typeof(KorisnikMetadata)),
                                                                  typeof(Korisnik));
        }

        internal sealed class KorisnikMetadata : NotifyContext
        {
            private int idKorisnik;
            private string nazivUstanove;
            private string laboratorija;
            private int pib;
            private string grad;
            private string adresa;
            private string postanskiBroj;
            private string telefon;

            [Key]
            public int IDKorisnik { get { return idKorisnik; } set { SetAndNotify(ref idKorisnik, value); } }

            [Required(ErrorMessage = "Naziv ustanove je obavezno polje!")]
            [StringLength(100, MinimumLength = 4, ErrorMessage = "Naziv ustanove sadrzi najmanje 4 slovna karaktera!")]
            public string NazivUstanove { get { return nazivUstanove; } set { SetAndNotify(ref nazivUstanove, value); } }

            [Required]
            [StringLength(100)]
            public string Laboratorija { get { return laboratorija; } set { SetAndNotify(ref laboratorija, value); } } //null

            [Required(ErrorMessage = "PIB je obavezno polje!")]
            [RegularExpression("^[0-9]*$", ErrorMessage = "PIB se sastoji samo od brojeva")]
            [MinLength(9)]
            public int PIB { get { return pib; } set { SetAndNotify(ref pib, value); } }

            [Required(ErrorMessage = "Grad je obavezno polje!")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "Naziv grada se sastoji od najmanje dva slovna karaktera!")]
            public string Grad { get { return grad; } set { SetAndNotify(ref grad, value); } }

            [Required(ErrorMessage = "Adresa je obavezno polje!")]
            [StringLength(200, MinimumLength = 4)]
            public string Adresa { get { return adresa; } set { SetAndNotify(ref adresa, value); } }

            [RegularExpression("^[0-9]*$", ErrorMessage = "Poštanski broj se sastoji samo od brojeva")]
            [Required(ErrorMessage = "Postanski broj je obavezno polje!")]
            public string PostanskiBroj { get { return postanskiBroj; } set { SetAndNotify(ref postanskiBroj, value); } }

            [Required(ErrorMessage = "Telefon je obavezno polje!")]
            public string Telefon { get { return telefon; } set { SetAndNotify(ref telefon, value); } }//null
        }
    }
}
