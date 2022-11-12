using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.CustomException
{
    public class ExceptionDecator:Exception
    {
        public Exception _exception;
        public ExceptionDecator(Exception exception)
        {
            _exception = exception;
        }
        public override string Message =>"This message from decator class"+base.Message;

    }
}
