using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoDiplomski.Utility;

namespace DemoDiplomski.ViewModel
{
    public class VMEntitetBase : NotifyContext
    {
        #region Polja
        private bool jeNovo = true;
        private bool jeSelektovano = false;
        private bool jeObrisano;
        protected object entitet;
        #endregion


        #region Svojstva
        public bool JeNovo
        {
            get
            {
                return jeNovo;
            }

            set
            {
                SetAndNotify(ref jeNovo, value);
            }
        }

        public bool JeSelektovano
        {
            get
            {
                return jeSelektovano;
            }

            set
            {
                SetAndNotify(ref jeSelektovano, value);
            }
        }

        public bool JeObrisano
        {
            get
            {
                return jeObrisano;
            }

            set
            {
                SetAndNotify(ref jeObrisano, value);
            }
        } 
        #endregion
    }
}
