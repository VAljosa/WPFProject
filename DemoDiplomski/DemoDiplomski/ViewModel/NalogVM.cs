using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DemoDiplomski.ViewModel
{
    public class NalogVM : ViewModelObject<Nalog>
    {
        private Nalog nalog;

        public Nalog Nalog
        {
            get
            {
                return nalog;
            }
        }


        public NalogVM(Nalog model) 
            : base(model)
        {
            this.nalog = model;
        }

        public void saveChanges()
        {
            //Cuvaju se promene unutar modela, ili Data izvora
        }

    }
}
