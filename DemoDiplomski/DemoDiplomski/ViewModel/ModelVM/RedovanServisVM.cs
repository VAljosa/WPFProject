using DemoDiplomski.Model;

namespace DemoDiplomski.ViewModel.ModelVM
{
    public class RedovanServisVM : VMEntitetBase, IViewModel<RedovanServis>
    {
        public RedovanServis Model
        {
            get
            {
                return base.entitet as RedovanServis;
            }
            set
            {
                SetAndNotify(ref entitet, value);
            }
        }

        public RedovanServisVM() 
        {
            Model = new RedovanServis();
        }

    }
}
