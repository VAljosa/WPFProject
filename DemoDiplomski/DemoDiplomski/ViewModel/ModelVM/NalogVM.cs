using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DemoDiplomski.ViewModel.ModelVM
{
    public class NalogVM : VMEntitetBase, IViewModel<Nalog>
    {
        public Nalog Model
        {
            get
            {
                return base.entitet as Nalog;
            }
            set
            {
                SetAndNotify(ref entitet, value);
            }
        }


        public NalogVM()
        {
            Model = new Nalog();
        }

    }
}
