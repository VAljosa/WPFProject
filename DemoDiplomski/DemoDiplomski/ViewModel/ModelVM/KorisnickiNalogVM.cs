using DemoDiplomski.Model;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace DemoDiplomski.ViewModel.ModelVM
{
    public class KorisnickiNalogVM : VMEntitetBase, IViewModel<LogKorisnik>
    {

        public LogKorisnik Model
        {
            get
            {
                return base.entitet as LogKorisnik;
            }
            set
            {
                SetAndNotify(ref entitet, value);
            }
        }

        public KorisnickiNalogVM()
        {
            Model = new LogKorisnik();
        }

    }
}
