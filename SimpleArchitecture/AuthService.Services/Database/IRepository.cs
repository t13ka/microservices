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
        long Count();

        void Create(T entity);

        void Delete(long id);

        IList<T> GetAll();

        T GetById(long id);

        void Replace(T entity);

        IList<T> SearchFor(Expression<Func<T, bool>> predicate);

        void Update(T entity);
    }
}