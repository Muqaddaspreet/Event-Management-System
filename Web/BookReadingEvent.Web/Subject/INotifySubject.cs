using BookReadingEvent.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.Web.Subject
{
    public interface INotifySubject
    {
        void AddObserver(INotifyObservable observer);
        void NotifyObserver();
    }
}
