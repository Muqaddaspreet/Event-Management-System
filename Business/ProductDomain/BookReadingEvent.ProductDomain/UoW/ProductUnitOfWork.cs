using BookReadingEvent.Core.Data.Transaction;
using BookReadingEvent.Core.ExceptionManagement;
using BookReadingEvent.ProductDomain.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.UoW
{
    public class ProductUnitOfWork:UnitOfWork,IProductUnitOfWork
    {
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider ServiceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyProjectUnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public ProductUnitOfWork(ProductDomainDbContext dbContext, IExceptionManager exceptionManager)
            : base(dbContext, exceptionManager)
        {
            //ServiceProvider = serviceProvider;
        }
    }
}
