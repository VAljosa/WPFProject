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
    public class ReversVM : IViewModel<Revers>
    {
        private Revers revers;
        private ObservableCollection<Revers> reversi;
        public ObservableCollection<Revers> Reversi
        {
            get
            {
                return reversi;
            }

            set
            {
                SetAndNotify(ref reversi, value);
            }
        }
        public Revers Model
        {
            get
            {
                return revers;
            }
            set
            {
                SetAndNotify(ref revers, value);
            }
        }


        public ReversVM()
        {
            Model = new Revers();
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
