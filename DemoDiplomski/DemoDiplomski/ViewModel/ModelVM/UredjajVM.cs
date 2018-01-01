using DemoDiplomski.Model;

namespace DemoDiplomski.ViewModel.ModelVM
{
    public class UredjajVM : VMEntitetBase, IViewModel<Uredjaj>
    {
        public Uredjaj Model
        {
            get
            {
                return base.entitet as Uredjaj;
            }
            set
            {
                SetAndNotify(ref entitet, value);
            }
        }


        public UredjajVM()           
        {
            Model = new Uredjaj();
        }

    }
}
