using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.ExceptionManagement
{
    public class ExceptionBase:Exception
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        public ExceptionBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ExceptionBase(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        public ExceptionBase(ErrorCodeType errorCode)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ExceptionBase(string message, ErrorCodeType errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ExceptionBase(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionBase" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ExceptionBase(string message, Exception innerException, ErrorCodeType errorCode)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public ErrorCodeType ErrorCode { get; protected set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text message.</value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; set; }
        #endregion

    }
}
