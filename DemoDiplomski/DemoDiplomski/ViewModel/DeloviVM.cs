using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace DemoDiplomski.ViewModel
{
    public class DeloviVM : ViewModelObject<Servis_Delovi>
    {
        private Servis_Delovi deo;

        public Servis_Delovi Deo
        {
            get
            {
                return deo;
            }
        }


        public DeloviVM(Servis_Delovi model)
            : base(model)
        {
            this.deo = model;
        }


        public void saveChanges()
        {
            //Cuvaju se promene unutar modela, ili Data izvora
        }
    }
}
