using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoDiplomski.ViewModel
{
    public class RedovanServisVM : ViewModelObject<RedovanServis>
    {
        private RedovanServis redovanServis;

        public RedovanServis RedovanServis
        {
            get
            {
                return redovanServis;
            }
        }

        public RedovanServisVM(RedovanServis model) 
            : base(model)
        {
            redovanServis = model;
        }

        public void saveChanges()
        {
            //Cuvaju se promene unutar modela, ili Data izvora
        }

    }
}
