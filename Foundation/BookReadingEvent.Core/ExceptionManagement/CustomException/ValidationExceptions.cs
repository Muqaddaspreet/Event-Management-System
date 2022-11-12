using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookReadingEvent.Core.ExceptionManagement.CustomException
{
    public class ValidationExceptions : Exception
    {
        public List<ValidationException> validationExceptionList;
        public ValidationExceptions()
        {

        }

        public ValidationExceptions(List<ValidationException> exceptions)
        {
            this.validationExceptionList = exceptions;
        }
    }
}
