using BookReadingEvent.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookReadingEvent.Core.Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : DomainBase
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>Total rows count.</value>
        int Count { get; }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>All records from model</returns>
        IQueryable<TEntity> All();

        /// <summary>
        /// Gets model by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Entity</returns>
        TEntity GetById(object id);

        /// <summary>
        /// Gets objects via optional filter, sort order, and includes.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns>IQueryable for model entity</returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null);

        /// <summary>
        /// Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate">Specified filter</param>
        /// <returns>IQueryable for model entity</returns>
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets objects from database with filtering and paging.
        /// </summary>
        /// <param name="filter">Specified filter.</param>
        /// <param name="total">Returns the total records count of the filter.</param>
        /// <param name="index">Page index.</param>
        /// <param name="size">Page size.</param>
        /// <returns>IQueryable for model entity</returns>
        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50);

        /// <summary>
        /// Gets the object(s) is exists in database by specified filter.
        /// </summary>
        /// <param name="predicate">Specified filter expression</param>
        /// <returns><c>true</c> if contains the specified filter; otherwise, /c>.</returns>
        bool Contains(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Find object by specified expression.
        /// </summary>
        /// <param name="predicate">Specified filter.</param>
        /// <returns>Search result</returns>
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <param name="entity">A new object to create.</param>
        /// <returns>Created object</returns>
        void Create(TEntity entity);

        /// <summary>
        /// Deletes the object by primary key
        /// </summary>
        /// <param name="id">Object key</param>
        void Delete(object id);

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="entity">Specified a existing object to delete.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate">Specify filter.</param>
        void Delete(Expression<Func<TEntity, bool>> predicate);
    }
}
