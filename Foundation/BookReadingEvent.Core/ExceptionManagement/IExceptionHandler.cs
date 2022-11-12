using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.ExceptionManagement
{
    public interface IExceptionHandler
    {
        Exception Process(Exception exception);
    }
}
