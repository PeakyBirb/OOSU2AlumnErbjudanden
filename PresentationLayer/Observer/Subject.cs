using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Observer
{
    public class Subject : ISubject
    {
        public void register(IObserver observer)
        {
            observers.Add(observer);
        }

        public void unregister(IObserver observer)
        {
            observers.Remove(observer);
        }

        List<IObserver> observers = new List<IObserver>();

        public void notifyAll()
        {
            foreach (IObserver observer in observers)
            {
                observer.update();
            }
        }

    }
}
