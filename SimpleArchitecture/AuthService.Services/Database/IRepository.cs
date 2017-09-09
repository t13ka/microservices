namespace AuthService.Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using AuthService.Core;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="T">
    /// some type
    /// </typeparam>
    internal interface IRepository<T>
        where T : IEntity
    {
        /// <summary>
        /// Get count
        /// </summary>
        /// <returns>
        /// Count of elements
        /// </returns>
        long Count();

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);

        /// <summary>
        /// Update instance
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<T> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetById(string id);

        /// <summary>
        /// Update instance
        /// </summary>
        /// <param name="entity"></param>
        void Replace(T entity);

        /// <summary>
        /// The search for.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<T> SearchFor(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Update instance
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }
}