using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// Gets a value indicating whether this instance is debug enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is debug enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is error enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is error enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsErrorEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is info enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is info enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is warning enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is warning enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsWarningEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is trace enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is trace enabled; otherwise, <c>false</c>.
        /// </value>
        bool IsTraceEnabled { get; }

        /// <summary>
        /// Logs less detailed and/or less frequent debugging messages.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogDebug(object message);

        /// <summary>
        /// Logs the error message
        /// </summary>
        /// <param name="message">The message.</param>
        void LogError(string message);

        /// <summary>
        /// Logs the error with specified exception
        /// </summary>
        /// <param name="exceptionToLog">The exception to log.</param>
        void LogError(Exception exceptionToLog);

        /// <summary>
        /// Logs the error message and exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void LogError(object message, Exception exception);

        /// <summary>
        /// Logs informational messages.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogInfo(object message);

        /// <summary>
        /// Logs warnings messages.
        /// </summary>
        /// <param name="message">The message.</param>
        void LogWarning(object message);

        /// <summary>
        /// Logs the trace messsages which are very detailed log messages, potentially of a high frequency and volume
        /// </summary>
        /// <param name="message">The message.</param>
        void LogTrace(object message);
    }
}
