using BookReadingEvent.Core.Domain.Domain;
using BookReadingEvent.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookReadingEvent.Core.Data.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : DomainBase, IDomain
    {
        /// <summary>
        /// DB context
        /// </summary>
        protected DbContext dbContext;
        protected readonly DbSet<TEntity> dbset;

        protected Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbset = dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>Total rows count.</value>
        public virtual int Count
        {
            get { return dbContext.Set<TEntity>().Count(); }
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>All records from model</returns>
        public virtual IQueryable<TEntity> All()
        {
            return dbContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets model by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>DB Model</returns>
        public virtual TEntity GetById(object id)
        {
            return dbContext.Set<TEntity>().Find(id);

        }

        /// <summary>
        /// Gets objects via optional filter, sort order, and includes.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns>IQueryable for model entity</returns>
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbContext.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return orderBy != null ? orderBy(query).AsQueryable() : query.AsQueryable();
        }

        /// <summary>
        /// Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate">Specified filter</param>
        /// <returns>IQueryable for model entity</returns>
        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate).AsQueryable();
        }

        /// <summary>
        /// Gets objects from database with filtering and paging.
        /// </summary>
        /// <param name="filter">Specified filter.</param>
        /// <param name="total">Returns the total records count of the filter.</param>
        /// <param name="index">Page index.</param>
        /// <param name="size">Page size.</param>
        /// <returns>IQueryable for model entity</returns>
        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50)
        {
            var skipCount = index * size;
            var resetSet = filter != null ? dbContext.Set<TEntity>().Where(filter).AsQueryable()
                : dbContext.Set<TEntity>().AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        /// <summary>
        /// Gets the object(s) is exists in database by specified filter.
        /// </summary>
        /// <param name="predicate">Specified filter expression</param>
        /// <returns><c>true</c> if contains the specified filter; otherwise, /c>.</returns>
        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Any(predicate);
        }

        /// <summary>
        /// Find object by specified expression.
        /// </summary>
        /// <param name="predicate">Specified filter.</param>
        /// <returns>Search result</returns>
        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <param name="entity">A new object to create.</param>
        /// <returns>Created object</returns>
        public virtual void Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Deletes the object by primary key
        /// </summary>
        /// <param name="id">Object key</param>
        public virtual void Delete(object id)
        {
            var entityToDelete = GetById(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="entity">Specified a existing object to delete.</param>
        public virtual void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate">Specify filter.</param>
        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToDelete = Filter(predicate);
            foreach (var entity in entitiesToDelete)
            {
                dbContext.Set<TEntity>().Remove(entity);
            }
        }
    }
}
