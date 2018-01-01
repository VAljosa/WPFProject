using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDiplomski
{
    public interface IViewModel<M> : INotifyPropertyChanged
    {
        M Model { get; }
    }

}
