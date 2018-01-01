using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoDiplomski.ViewModel
{
    
    //Ova klasa implementira interfejs IViewModel, koji je veza sa modelom
    //Klasa olaksava posao nasledjivanja
    public class ViewModelObject<M> : IViewModel<M> , INotifyPropertyChanged
    {
        private M model;

        

        public M Model
        {
            get{ return model; }

        }

        public ViewModelObject(M model)
        {
            this.model = model;
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
