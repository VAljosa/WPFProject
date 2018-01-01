using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DemoDiplomski.ViewModel;

namespace DemoDiplomski.ViewModel.ModelVM
{
    public class DostavnicaVM : VMEntitetBase, IViewModel<Dostavnica>
    {

        public Dostavnica Model
        {
            get
            {
                return base.entitet as Dostavnica;
            }
            set
            {
                SetAndNotify(ref entitet, value);
            }
        }

        public DostavnicaVM()
        {
            Model = new Dostavnica();
        }

    }
}
