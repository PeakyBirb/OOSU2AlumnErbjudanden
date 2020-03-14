using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Observer
{
    public interface ISubject
    {
        void register(IObserver observer);
        void unregister(IObserver observer);
        void notifyAll();
    }
}
