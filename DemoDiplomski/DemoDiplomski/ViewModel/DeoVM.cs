using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace DemoDiplomski.ViewModel
{
    public class DeoVM : IViewModel<Deo>
    {
        private Deo deo;
        private bool noviDeo = true;
        public bool NoviDeo
        {
            get
            {
                return noviDeo;
            }

            set
            {
                SetAndNotify(ref noviDeo, value);
            }
        }

        public CollectionView DeoView { get; set; }

        public Deo Model
        {
            get
            {
                return deo;
            }
            set
            {
                SetAndNotify(ref deo, value);
            }
        }


        public DeoVM()
        {
            Model = new Deo();
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
