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
    [MetadataType(typeof(UredjajMetadata))]
    public partial class Uredjaj : EntityErrorLogic
    {
        public void MetaDataSet()
        {
            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Uredjaj),
                                                                  typeof(UredjajMetadata)),
                                                                  typeof(Uredjaj));

        }

        internal sealed class UredjajMetadata : NotifyContext
        {
            private string s_N;
            private string tip;
            private string detalji;

            [Column("S/N")]
            [Required(ErrorMessage = "S/N (Serijski broj) je obavezno polje!")]
            [StringLength(10)]
            [MinLength(4, ErrorMessage = "Nije dobar unos!")]
            public string S_N { get { return s_N; } set { SetAndNotify(ref s_N, value); } }

            [Required(ErrorMessage = "Tip uredjaja je obavezno polje!")]
            [StringLength(50)]
            public string Tip { get { return tip; } set { SetAndNotify(ref tip, value); } }

            public string Detalji { get { return detalji; } set { SetAndNotify(ref detalji, value); } }
        }
    }
}
