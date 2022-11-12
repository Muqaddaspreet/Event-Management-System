using BookReadingEvent.Core.Data.Transaction;
using BookReadingEvent.Core.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.AppServices
{
    public abstract class AppService : IAppService
    {
        /// <summary>
        /// The _exception manager
        /// </summary>
        protected IExceptionManager ExceptionMgr;

        /// <summary>
        /// The _unit of work
        /// </summary>
        protected IUnitOfWork UnitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppService"/> class.
        /// </summary>
        /// 
        public AppService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="exceptionManager">The exception manager.</param>
        public AppService(IUnitOfWork unitOfWork, IExceptionManager exceptionManager)
        {
            this.UnitOfWork = unitOfWork;
            this.ExceptionMgr = exceptionManager;
        }
    }
}
