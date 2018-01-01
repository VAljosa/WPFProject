using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DemoDiplomski.Utility
{
    public delegate void NavigacijaHendler(bool vratiDialog);

    public interface IModalServisUserControl
    {
        void OtvoriUC(UserControl uc, NavigacijaHendler vratiUC);
        void ZatvoriUC(bool vratiVrednost);
    }
}
