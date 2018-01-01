using DemoDiplomski.Model;
using DemoDiplomski.Utility;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static DemoDiplomski.ViewControl.UredjajViewControls;
using System.Collections.Specialized;
using System.Data.Entity;

namespace DemoDiplomski.ViewModel
{
    public class UredjajViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<UredjajVM> uredjaji = new ObservableCollection<UredjajVM>();
        private CollectionViewSource cvsUredjaj;
        private TehnoklinikContext tehnoContext;

        private UredjajVM tekuciUredjaj;
        private ICollectionView uredjajCV;
        public ICollectionView UredjajCV
        {
            get
            {
                return cvsUredjaj.View;
            }
            set
            {
                SetAndNotify(ref uredjajCV, value);
            }
        }

        public ObservableCollection<UredjajVM> Uredjaji
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

        public UredjajVM TekuciUredjaj
        {
            get
            {
                return tekuciUredjaj;
            }

            set
            {
                SetAndNotify(ref tekuciUredjaj, value);
            }
        }

        public UredjajViewModel()
        {
            tehnoContext = new TehnoklinikContext();
            DohvatiUredjaje();
            //cvs = new CollectionViewSource();
            //cvs.Source = Uredjaji;

        }

        private async void DohvatiUredjaje()
        {
            ObservableCollection<UredjajVM> uredjaji_U = new ObservableCollection<UredjajVM>();
            var uredjajUpit = await(from u in tehnoContext.Uredjaji
                                    select u).ToListAsync();

            await Task.Delay(100);           
            foreach (Uredjaj u in uredjajUpit)
            {
                uredjaji_U.Add(new UredjajVM { Model = u});
            }
            Uredjaji = uredjaji_U;
        }


        //public object RefreshView()//Refresh metoda baca izuzetak kod dodavanja objekta u grid
        //{
        //    UredjajView.Refresh();
        //    RaisePropertyChanged("UredjajView");
        //    return null;
        //}

        //private void Uredjaji_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    RefreshView();
        //}

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
