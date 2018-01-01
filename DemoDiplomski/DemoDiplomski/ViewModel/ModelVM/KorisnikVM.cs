using DemoDiplomski.Model;

namespace DemoDiplomski.ViewModel.ModelVM
{
    public class KorisnikVM : VMEntitetBase, IViewModel<Korisnik>
    {

        public Korisnik Model
        {
            get
            {
                return base.entitet as Korisnik;
            }
            set
            {
                SetAndNotify(ref entitet, value);
            }
        }

        public KorisnikVM()
        {
            Model = new Korisnik();
        }
    }
}
