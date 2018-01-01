using DemoDiplomski.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DemoDiplomski.ViewModel
{
    public class DeloviViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DeoVM> delovi = new ObservableCollection<DeoVM>();
        private ICollectionView deoCV;
        private CollectionViewSource cvsDeo;
        private TehnoklinikContext tehnoContext;
        private DeoVM tekuciDeo;

        public ObservableCollection<DeoVM> Delovi
        {
            get
            {
                return delovi;
            }

            set
            {
                SetAndNotify(ref delovi, value);
            }
        }

        public DeoVM TekuciDeo
        {
            get
            {
                return tekuciDeo;
            }

            set
            {
                SetAndNotify(ref tekuciDeo, value);
            }
        }

        public ICollectionView DeoCV
        {
            get
            {
                return deoCV;
            }

            set
            {
                SetAndNotify(ref deoCV, value);
            }
        }

        public DeloviViewModel()
        {
            tehnoContext = new TehnoklinikContext();
            DohvatiDelove();
        }

        private async void DohvatiDelove()
        {
            ObservableCollection<DeoVM> delovi_D = new ObservableCollection<DeoVM>();
            var deoUpit = await (from d in tehnoContext.Delovi
                                 select d).ToListAsync();
            await Task.Delay(100);
            foreach(Deo d in deoUpit)
            {
                delovi_D.Add(new DeoVM { Model = d});
            }
            Delovi = delovi_D;

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
