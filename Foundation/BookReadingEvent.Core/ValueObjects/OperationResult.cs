using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookReadingEvent.Core.ValueObjects
{
    public class OperationResult
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="mainMessage">The main message.</param>
        /// 
        public OperationResult(bool isSuccess, Message mainMessage)
            : this(isSuccess, mainMessage, Enumerable.Empty<Message>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="mainMessage">The main message.</param>
        /// <param name="associatedMessages">The associated messages.</param>
        /// 
        public OperationResult(bool isSuccess, Message mainMessage, IEnumerable<Message> associatedMessages)
        {
            this.IsSuccess = isSuccess;
            this.MainMessage = mainMessage;
            //this.InternalMessages = associatedMessages;
            this.AssociatedMessages = associatedMessages;
        }
        #endregion

        /// <summary>
        /// Gets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>

        public bool IsSuccess { get; private set; }

        /// <summary>
        /// Gets the main message.
        /// </summary>
        /// <value>
        /// The main message.
        /// </value>
        /// 

        public Message MainMessage { get; private set; }


        /// <summary>
        /// Gets the associated messages.
        /// </summary>
        /// <value>
        /// The associated messages.
        /// </value>
        /// 

        public IEnumerable<Message> AssociatedMessages
        {
            get; private set;
        }
    }

    /// <summary>
    /// Represents the result (with data) of an operation/action (method call)
    /// DEVNOTE: This must not be used to wrap exceptions. Exceptions must be propagated upchain through exception handling.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 

    public class OperationResult<T> : OperationResult
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="mainMessage">The main message.</param>
        /// 
        public OperationResult(T data, bool isSuccess, Message mainMessage)
            : this(data, isSuccess, mainMessage, Enumerable.Empty<Message>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="mainMessage">The main message.</param>
        /// <param name="associatedMessages">The associated messages.</param>
        /// 
        public OperationResult(T data, bool isSuccess, Message mainMessage, IEnumerable<Message> associatedMessages)
            : base(isSuccess, mainMessage, associatedMessages)
        {
            this.Data = data;
        }
        #endregion

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>

        public T Data { get; private set; }

    }
}
