using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DemoDiplomski.ViewModel.ModelVM
{
    public class VandredniServisVM : VMEntitetBase, IViewModel<VandredniServis>
    {
        public VandredniServis Model
        {
            get
            {
                return base.entitet as VandredniServis;
            }
            set
            {
                SetAndNotify(ref entitet, value);
            }
        }

        public VandredniServisVM()
        {
            Model = new VandredniServis();
        }
    }
}
