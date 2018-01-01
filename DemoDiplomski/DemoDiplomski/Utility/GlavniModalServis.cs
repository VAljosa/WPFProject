using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemoDiplomski.Utility
{
    public class GlavniModalServis
    {
        public static IModalServisUserControl ModalServis
        {
            get { return Application.Current.MainWindow as IModalServisUserControl; }
        }
    }
}
