using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.ExceptionManagement
{
    public interface IExceptionManager
    {
        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        void HandleException(Exception exception);

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="additionalMessage">The additional message.</param>
        void HandleException(Exception exception, string additionalMessage);

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="additionalMessage">The additional message.</param>
        /// <param name="sendNotification">If set to <c>true</c> send notification.</param>  
        void HandleException(Exception exception, string additionalMessage, bool sendNotification);

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exceptionHandler">The exception handler.</param>
        /// <returns></returns>
        void HandleException(Exception exception, IExceptionHandler exceptionHandler, out Exception exceptionToThrow);
    }
}
