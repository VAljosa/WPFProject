using DemoDiplomski.Model;

namespace DemoDiplomski.ViewModel.ModelVM
{
    public class DeoVM : VMEntitetBase, IViewModel<Deo>
    {

        public Deo Model
        {
            get
            {
                return base.entitet as Deo;
            }
            set
            {
                SetAndNotify(ref entitet, value);
            }
        }


        public DeoVM()
        {
            Model = new Deo();
        }

    }
}
