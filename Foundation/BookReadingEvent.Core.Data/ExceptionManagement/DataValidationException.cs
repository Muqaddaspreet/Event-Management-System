using BookReadingEvent.Core.ExceptionManagement;
using BookReadingEvent.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.Data.ExceptionManagement
{
    public class DataValidationException : ExceptionBase
    {
        /// <summary>
        /// The _validation errors
        /// </summary>
        /// 
        private IEnumerable<Message> _validationErrors;

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="DataValidationException"/> class.
        /// </summary>
        /// 
        public DataValidationException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataValidationException"/> class.
        /// </summary>
        /// <param name="validationErrors">The validation errors.</param>
        /// 
        public DataValidationException(IEnumerable<Message> validationErrors)
        {
            this._validationErrors = validationErrors;
        }


        #endregion

        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        /// <value>
        /// The validation errors.
        /// </value>
        /// 
        public IEnumerable<Message> ValidationErrors { get { return _validationErrors; } }
    }
}
