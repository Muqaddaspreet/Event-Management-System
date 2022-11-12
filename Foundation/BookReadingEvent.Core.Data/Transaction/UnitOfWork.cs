using BookReadingEvent.Core.Data.ExceptionManagement;
using BookReadingEvent.Core.ExceptionManagement;
using BookReadingEvent.Core.ExceptionManagement.CustomException;
using BookReadingEvent.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvent.Core.Data.Transaction
{
    public abstract class UnitOfWork
      : IUnitOfWork
    {
        private readonly DbContext DbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork{TContext}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected UnitOfWork(DbContext context, IExceptionManager exceptionManager)
        {
            DbContext = context;
            _exceptionManager = exceptionManager;
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        internal virtual DbContext Context
        {
            get
            {
                return DbContext;
            }
        }

        /// <summary>
        /// To detect redundant calls
        /// </summary>
        private bool _disposedValue;

        /// <summary>
        /// Dispose the object
        /// </summary>
        /// <param name="disposing">IsDisposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (DbContext != null)
                    {
                        DbContext.Dispose();
                    }
                }
            }
            _disposedValue = true;
        }

        /// <summary>
        /// Dispose the object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveAsyc()
        {
            return Context.SaveChangesAsync();
        }
        private readonly IExceptionManager _exceptionManager;
        public OperationResult Commit()
        {
            bool result = false;
            Message mainMessage;
            IEnumerable<Message> associatedMessages = Enumerable.Empty<Message>();
            try
            {
                int changeCount = Context.SaveChanges();
                if (changeCount > 0)
                {
                    result = true;
                    mainMessage = new Message(string.Empty, "Data saved successfully.");
                }
                else
                {
                    mainMessage = new Message(string.Empty, "Database changes not saved !");
                }

            }
            catch (ValidationExceptions exception)
            {
                mainMessage = new Message(string.Empty, "Data not saved due to an error!");
                Exception exceptionToThrow;
                _exceptionManager.HandleException(exception, new DataExceptionHandler(), out exceptionToThrow);
                if (exceptionToThrow.GetType() == typeof(DataValidationException))
                {
                    associatedMessages = ((DataValidationException)exceptionToThrow).ValidationErrors;
                }

                _exceptionManager.HandleException(exception, mainMessage.Text);
            }
            catch (Exception exception)
            {
                mainMessage = new Message(string.Empty, "Data not saved due to an error!");
                _exceptionManager.HandleException(exception, mainMessage.Text);
            }

            return new OperationResult(result, mainMessage, associatedMessages);
        }

        public void Rollback()
        {
            DbContext.Database.RollbackTransaction();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return DbContext.Database.BeginTransaction();
        }
    }
}
