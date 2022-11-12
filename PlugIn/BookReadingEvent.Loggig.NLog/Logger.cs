using BookReadingEvent.Core.Logging;
using System;
using NLog;

namespace BookReadingEvent.Loggig.NLog
{
    public class Logger : LoggerBase
    {
        #region Private variables
        /// <summary>
        /// The _logger
        /// </summary>
        private readonly global::NLog.Logger _logger;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }

        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Logger()
        {
            _logger = LogManager.GetCurrentClassLogger();

            // TODO : Read these settings based on NLog configuration.
            this.IsDebugEnabled = true;
            base.IsErrorEnabled = true;
            base.IsInfoEnabled = true;
            base.IsWarningEnabled = true;
        }
        #endregion

        #region Protected methods
        /// <summary>
        /// Called when [log debug].
        /// </summary>
        /// <param name="message">The message.</param>
        protected override void OnLogDebug(object message)
        {
            _logger.Log(LogLevel.Debug, message.ToString());
        }

        /// <summary>
        /// Called when [log error].
        /// </summary>
        /// <param name="message">The message.</param>
        protected override void OnLogError(string message)
        {
            _logger.Log(LogLevel.Error, message);
        }

        /// <summary>
        /// Called when [log error].
        /// </summary>
        /// <param name="exceptionToLog">The exception to log.</param>
        protected override void OnLogError(Exception exceptionToLog)
        {
            _logger.Log(LogLevel.Error, exceptionToLog);
        }

        /// <summary>
        /// Called when [log error].
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        protected override void OnLogError(object message, Exception exceptionToLog)
        {
            _logger.Log(LogLevel.Error, exceptionToLog, message.ToString());
        }

        /// <summary>
        /// Called when [log info].
        /// </summary>
        /// <param name="message">The message.</param>
        protected override void OnLogInfo(object message)
        {
            _logger.Log(LogLevel.Info, message.ToString());
        }

        /// <summary>
        /// Called when [log warning].
        /// </summary>
        /// <param name="message">The message.</param>
        protected override void OnLogWarning(object message)
        {
            _logger.Log(LogLevel.Warn, message.ToString());
        }
        #endregion
    }
}
