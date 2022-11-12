using BookReadingEvent.Core.ExceptionManagement.CustomException;
using BookReadingEvent.ProductDomain.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BookReadingEvent.ProductDomain.Data.DBContext
{
    public class ProductDomainDbContext : DbContext
    {
      
        public DbSet<Product> Products { get; set; }


        public ProductDomainDbContext(DbContextOptions options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            string errorMessage = string.Empty;
            var entities = (from entry in ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            List<ValidationException> validationExceptionList = new List<ValidationException>();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults, true))
                {
                    foreach (var result in validationResults)
                    {
                        if (result != ValidationResult.Success)
                        {
                            validationExceptionList.Add(new ValidationException(result.ErrorMessage));
                        }
                    }

                    throw new ValidationExceptions(validationExceptionList);
                }
            }

            return base.SaveChanges();
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> UserAccounts { get; set; }
        public DbSet<EventCreate> EventDetailTable { get; set; }
    }
}
