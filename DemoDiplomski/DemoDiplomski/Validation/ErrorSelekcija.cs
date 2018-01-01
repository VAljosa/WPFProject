using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDiplomski.Validation
{
    public enum SourceOfError
    {
        Conversion, Validation
    }
    //AnError klasa u WpfEF primeru
    public class ErrorSelekcija
    {
        public string Tekst { get; set; }
        public SourceOfError Source;
    }
}
