using BookReadingEvent.Core.Data.DataAccess;
using BookReadingEvent.ProductDomain.Data.DBContext;
using BookReadingEvent.ProductDomain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
            public ProductRepository(ProductDomainDbContext context) : base(context)
            {
            }
    }
}
