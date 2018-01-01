using DemoDiplomski.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDiplomski.Model
{
    [MetadataType(typeof(DeoMetadata))]
    public partial class Deo : EntityErrorLogic
    {
        public void MetaDataSet()
        {
            TypeDescriptor.AddProviderTransparent
            (
                new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Deo),
                                                                  typeof(DeoMetadata)),
                                                                  typeof(Deo));
        }

        internal sealed class DeoMetadata : NotifyContext
        {
            private string s_N;
            private string naziv;
            private int? kolicina;
            private bool naStanju;
            private decimal? cena;

            [Column("S/N")]
            [Required]
            [StringLength(10)]
            public string S_N { get { return s_N; } set { SetAndNotify(ref s_N, value); } }

            [Required]
            [StringLength(50)]
            public string Naziv { get { return naziv; } set { SetAndNotify(ref naziv, value); } }

            public int? Kolicina { get { return kolicina; } set { SetAndNotify(ref kolicina, value); } }

            public bool NaStanju { get { return naStanju; } set { SetAndNotify(ref naStanju, value); } }

            [Column(TypeName = "money")]
            public decimal? Cena { get { return cena; } set { SetAndNotify(ref cena, value); } }
        }
    }
}
