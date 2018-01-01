using DemoDiplomski.Message;
using DemoDiplomski.Model;
using DemoDiplomski.Utility;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDiplomski.ViewModel
{
    public class CrudVMBase : NotifyContext
    {
        protected TehnoklinikModel db = new TehnoklinikModel();

        #region polja
        private bool jeUEditModu = false;
        private string errorPoruka;
        protected object selektovaniEntitet;
        protected object editovaniEntitet;
        protected bool jeTekucaUC = false;
        #endregion

        #region Svojstva
        public bool JeUEditModu
        {
            get
            {
                return jeUEditModu;
            }
            set
            {
                jeUEditModu = value;
                EditMode em = new EditMode { Mode = value };
                NotifyPropertyChanged();
            }
        }
        public string ErrorPoruka
        {
            get
            {
                return errorPoruka;
            }

            set
            {
                errorPoruka = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Konstruktor
        public CrudVMBase()
        {
            //DohvatiPodatke();
            //Messenger.Default.Register<UINavigacija>(this, (action) => TekucaUC(action));
        }
        #endregion

        public bool JeSelektovaniObj()
        {
            bool ok = true;
            if (selektovaniEntitet == null)
            {
                ok = false;
                PrikaziUIPoruku("Selektujte red za dalji rad!");

            }
            return ok;
        }


        //Ova metoda prosledjuje Messenger.Default.Send 
        protected void PrikaziUIPoruku(string poruka)
        {
            UIPoruka msg = new UIPoruka { Poruka = poruka };
            Messenger.Default.Send<UIPoruka>(msg);
        }

        protected virtual void DodajAzuriraj() { }

        protected virtual void Izadji() { }

        protected virtual void DodajNovo() { }

        public virtual void Azuriraj() { }

        protected virtual void ObrisiTekuce() { }

        protected virtual void Sacuvaj() { }

        protected virtual void DohvatiPodatke() { }

        protected virtual void DohvatiKorisnike() { }

        protected virtual void DohvatiUredjaje() { }

        protected virtual void DohvatiDelove() { }

        public virtual void OsveziPodatke()
        {
            DohvatiPodatke();
            Messenger.Default.Send<UIPoruka>(new UIPoruka { Poruka = "Podaci su osveženi!" });
        }


    }
}
