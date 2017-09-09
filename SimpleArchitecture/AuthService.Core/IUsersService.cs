namespace AuthService.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The UserService interface.
    /// </summary>
    public interface IUsersService
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
        void Create(IUser entity);

        /// <summary>
        /// Update instance
        /// </summary>
        /// <param name="id"></param>
        void Delete(string id);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{T}"/>.
        /// </returns>
        IList<IUser> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        IUser GetById(string id);

        /// <summary>
        /// Update instance
        /// </summary>
        /// <param name="entity"></param>
        void Replace(IUser entity);

        /// <summary>
        /// The search for.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IList{T}"/>.
        /// </returns>
        IList<IUser> SearchFor(Expression<Func<IUser, bool>> predicate);

        /// <summary>
        /// Update instance
        /// </summary>
        /// <param name="entity"></param>
        void Update(IUser entity);
    }
}