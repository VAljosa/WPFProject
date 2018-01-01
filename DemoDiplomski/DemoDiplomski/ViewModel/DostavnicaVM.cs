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
    public class DostavnicaVM : IViewModel<Dostavnica>
    {
        private Dostavnica servis;

        public Dostavnica Model
        {
            get
            {
                return servis;
            }
            set
            {
                SetAndNotify(ref servis, value);
            }
        }

        public DostavnicaVM()
        {
            Model = new Dostavnica();
        }

        public void saveChanges()
        {
            //Cuvaju se promene unutar modela, ili Data izvora
        }

        #region PropertyChangedImpl
        protected void SetAndNotify<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                NotifyPropertyChanged(propertyName);
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


    }
}
