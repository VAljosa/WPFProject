using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDiplomski.Utility
{
    public class VMEntitetBase : NotifyContext
    {
        #region Polja
        private bool isNew = true;
        private bool isSelected = false;
        private bool isDeleted;
        protected object entitet;
        #endregion


        #region Svojstva
        public bool IsNew
        {
            get
            {
                return isNew;
            }

            set
            {
                isNew = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
                NotifyPropertyChanged();
            }
        } 
        #endregion
    }
}
