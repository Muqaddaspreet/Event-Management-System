using BookReadingEvent.Core.ExceptionManagement;
using BookReadingEvent.Core.ExceptionManagement.CustomException;
using BookReadingEvent.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BookReadingEvent.Core.Data.ExceptionManagement
{
    public sealed class DataExceptionHandler : IExceptionHandler
    {
        public DataExceptionHandler()
        {

        }

        public Exception Process(Exception exception)
        {
            IEnumerable<Message> errorMessages = null;
            if (exception.GetType() == typeof(ValidationException))
            {
                errorMessages = GetErrors((ValidationException)exception);
            }
            else if (exception.GetType() == typeof(ValidationExceptions))
            {
                errorMessages = GetErrors((ValidationExceptions)exception);
            }
            else if (exception.GetType() == typeof(DbUpdateException))
            {
                errorMessages = this.GetErrors((DbUpdateException)exception);
            }
            else
            {
                errorMessages = this.GetErrors(exception);
            }
            return new DataValidationException(errorMessages);
        }


        private IEnumerable<Message> GetErrors(ValidationExceptions exception)
        {
            IList<Message> messages = new List<Message>();
            //  foreach(ValidationResult res in exception.)
            foreach (var result in exception.validationExceptionList)
            {
                Message msg = new Message(string.Empty, result.Message + result.InnerException);
                messages.Add(msg);
            }

            //foreach (ValidationResult validation in exception.)
            //{
            //    foreach (Validation propertyError in v)
            //    {
            //        Message msg = new Message(string.Empty,
            //            propertyError.ErrorMessage,
            //            propertyError.ErrorMessage,
            //            new List<string> { propertyError.PropertyName });

            //        messages.Add(msg);
            //    }
            //}

            return messages.AsEnumerable<Message>();
        }
        private IEnumerable<Message> GetErrors(ValidationException exception)
        {
            IList<Message> messages = new List<Message>();
            //  foreach(ValidationResult res in exception.)
            Message msg = new Message(string.Empty, exception.Message + exception.InnerException);
            //foreach (ValidationResult validation in exception.)
            //{
            //    foreach (Validation propertyError in v)
            //    {
            //        Message msg = new Message(string.Empty,
            //            propertyError.ErrorMessage,
            //            propertyError.ErrorMessage,
            //            new List<string> { propertyError.PropertyName });

            //        messages.Add(msg);
            //    }
            //}
            messages.Add(msg);
            return messages.AsEnumerable<Message>();
        }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        private IEnumerable<Message> GetErrors(DbUpdateException exception)
        {
            IList<Message> list = new List<Message>();
            Message message = null;
            if (exception.InnerException != null
                && exception.InnerException.GetType() == typeof(DbUpdateException)
                   && exception.InnerException.InnerException != null
                   && exception.InnerException.InnerException.GetType() == typeof(SqlException))
            {
                // 547, 2601, 2627
                SqlException sqlException = (SqlException)exception.InnerException.InnerException;

                //message = GetValidationResultBySqlExceptionErrorNumber(sqlException.Number, sqlException.Message);
                switch (sqlException.Number)
                {
                    case Constants.SQLErrorCodes.ForeignConstraintViolation:
                        //message = CreateValidationResultForForeignConstraintViolation(sqlErrorNumber, exceptionMessage);
                        message = new Message(Constants.SQLErrorCodes.ForeignConstraintViolation.ToString(), "Foriegn constraint violation!");
                        break;
                    case Constants.SQLErrorCodes.DuplicateKeyRowInsertion:
                        //message = CreateValidationResultForDuplicateKeyRowInsertion(sqlErrorNumber, exceptionMessage);
                        message = new Message(Constants.SQLErrorCodes.ForeignConstraintViolation.ToString(), "Duplication key!");
                        break;
                    case Constants.SQLErrorCodes.UniqueConstraintViolation:
                        message = new Message(Constants.SQLErrorCodes.ForeignConstraintViolation.ToString(), "Unique constraint violation!");
                        break;
                }
            }

            list.Add(message);

            return list.AsEnumerable<Message>();

        }

        private IEnumerable<Message> GetErrors(Exception exception)
        {
            IList<Message> list = new List<Message>();
            //TODO: Refine the messages
            Message message = new Message(ErrorCodeType.DataStore.ToString(), "Error while saving data in database!");
            list.Add(message);
            return list.AsEnumerable<Message>();
        }

    }
}
