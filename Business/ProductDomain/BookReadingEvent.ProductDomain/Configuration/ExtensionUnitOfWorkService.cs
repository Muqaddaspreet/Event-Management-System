using BookReadingEvent.ProductDomain.Repository;
using BookReadingEvent.ProductDomain.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.Configuration
{ /// <summary>
  /// Unit of work service
  /// </summary>
    public static class ExtensionUnitOfWorkService
    {
        /// <summary>
        /// Registers the repositories.
        /// </summary>
        /// <param name="service">The service collection.</param>
		public static void RegisterRepositories(this IServiceCollection service)
        {
            service.AddSingleton<IProductRepository, ProductRepository>();
            service.AddSingleton<IProductUnitOfWork, ProductUnitOfWork>();
        }
    }
}
