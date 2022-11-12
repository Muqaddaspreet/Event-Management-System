using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.Logging
{
    public class LoggerBase:ILogger
    {
        /// <summary>
        /// Gets a value indicating whether this instance is debug enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is debug enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsDebugEnabled { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether this instance is error enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is error enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsErrorEnabled { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether this instance is info enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is info enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsInfoEnabled { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether this instance is warning enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is warning enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsWarningEnabled { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether this instance is trace enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is trace enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsTraceEnabled { get; protected set; }

        /// <summary>
        /// Logs less detailed and/or less frequent debugging messages.
        /// </summary>
        /// <param name="message">The message.</param>

        
        
        public void LogDebug(object message)
        {
            if (this.IsDebugEnabled)
            {
                this.OnLogDebug(message);
            }
        }

        /// <summary>
        /// Logs the error message
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogError(string message)
        {
            if (IsErrorEnabled)
            {
                this.OnLogError(message);
            }
        }

        /// <summary>
        /// Logs the error with specified exception
        /// </summary>
        /// <param name="exceptionToLog">The exception to log.</param>
        public void LogError(Exception exceptionToLog)
        {
            if (IsErrorEnabled)
            {
                this.OnLogError(exceptionToLog);
            }
        }

        /// <summary>
        /// Logs the error message and exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void LogError(object message, Exception exception)
        {
            if (IsErrorEnabled)
            {
                this.OnLogError(message, exception);
            }
        }

        /// <summary>
        /// Logs informational messages.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogInfo(object message)
        {
            if (IsInfoEnabled)
            {
                this.OnLogInfo(message);
            }
        }

        /// <summary>
        /// Logs warnings messages.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogWarning(object message)
        {
            if (IsWarningEnabled)
            {
                this.OnLogWarning(message);
            }
        }

        /// <summary>
        /// Logs the trace messsages which are very detailed log messages, potentially of a high frequency and volume
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void LogTrace(object message)
        {
            if (IsTraceEnabled)
            {
                this.OnLogTrace(message);
            }
        }

        #region Protected Methods
        /// <summary>
        /// Called when [log debug].
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected virtual void OnLogDebug(object message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [log error].
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected virtual void OnLogError(string message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [log error].
        /// </summary>
        /// <param name="exceptionToLog">The exception to log.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected virtual void OnLogError(Exception exceptionToLog)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [log error].
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected virtual void OnLogError(object message, Exception exception)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [log info].
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected virtual void OnLogInfo(object message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [log warning].
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected virtual void OnLogWarning(object message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [log trace].
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected virtual void OnLogTrace(object message)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
