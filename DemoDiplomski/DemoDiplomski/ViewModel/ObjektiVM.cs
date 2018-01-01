
using DemoDiplomski.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoDiplomski.ViewModel
{
    public class ObjektiVM : NotifyPropertyObject
    {
        private KorisnikVM tekuciKorisnik;
        private DeoVM tekuciDelovi;
        private UredjajVM tekuciUredjaj;

        public KorisnikVM TekuciKorisnik
        {
            get
            {
                return tekuciKorisnik;
            }

            set
            {
                SetAndNotify(ref tekuciKorisnik, value);
            }
        }

        public DeoVM TekuciDelovi
        {
            get
            {
                return tekuciDelovi;
            }

            set
            {
                SetAndNotify(ref tekuciDelovi, value);
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
    }
}
