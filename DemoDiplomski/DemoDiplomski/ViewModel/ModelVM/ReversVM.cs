using DemoDiplomski.Model;

namespace DemoDiplomski.ViewModel.ModelVM
{
    public class ReversVM : VMEntitetBase, IViewModel<Revers>
    {
        public Revers Model
        {
            get
            {
                return base.entitet as Revers;
            }
            set
            {
                SetAndNotify(ref entitet, value);
            }
        }


        public ReversVM()
        {
            Model = new Revers();
        }

    }
}
