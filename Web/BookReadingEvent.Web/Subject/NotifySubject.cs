using BookReadingEvent.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.Web.Subject
{
    public class NotifySubject : INotifySubject
    {
        INotifyObservable _observer;
        public void AddObserver(INotifyObservable observer)
        {
            _observer = observer;
            NotifyObserver();
        }

        public void NotifyObserver()
        {
            _observer.Notify();
        }
    }
}
