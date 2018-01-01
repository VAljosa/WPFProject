using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace DemoDiplomski.ViewModel
{
    public class UredjajVM : IViewModel<Uredjaj>
    {
        public Uredjaj uredjaj;
        public CollectionView UredjajCV { get; set; }

        private ObservableCollection<Uredjaj> uredjaji;
      
        public ObservableCollection<Uredjaj> Uredjaji
        {
            get
            {
                return uredjaji;
            }
            set
            {
                SetAndNotify(ref uredjaji, value);
            }
        }
        public Uredjaj Model
        {
            get
            {
                return uredjaj;
            }
            set
            {
                SetAndNotify(ref uredjaj, value);
            }
        }


        public UredjajVM()           
        {
            Model = new Uredjaj();
        }



        public int BrojReda
        {
            get
            {
                int row = -1;
                row = UredjajCV.IndexOf(this);
                return row + 1;
            }
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
