using System;

namespace AuthService.Services
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using AuthService.Core;
    using AuthService.Core.ConfigSections;
    using AuthService.Services.Database.Collections;

    using Microsoft.Extensions.Options;

    /// <summary>
    /// The users service.
    /// </summary>
    public class UsersService : IUsersService
    {
        /// <summary>
        /// The _users collection.
        /// </summary>
        private readonly UsersCollection _usersCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        /// <param name="databaseSettingsOptions">
        /// The database settings options.
        /// </param>
        public UsersService(IOptions<DatabaseSettings> databaseSettingsOptions)
        {
            _usersCollection = new UsersCollection(databaseSettingsOptions);
        }

        /// <summary>
        /// The count.
        /// </summary>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        public long Count()
        {
            return _usersCollection.Count();
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Create(IUser entity)
        {
            _usersCollection.Create(entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(string id)
        {
            _usersCollection.Delete(id);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<IUser> GetAll()
        {
            return _usersCollection.GetAll();
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IUser"/>.
        /// </returns>
        public IUser GetById(string id)
        {
            return _usersCollection.GetById(id);
        }

        /// <summary>
        /// The replace.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Replace(IUser entity)
        {
            _usersCollection.Replace(entity);
        }

        /// <summary>
        /// The search for.
        /// </summary>
        /// <param name="predicate">
        /// The predicate.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<IUser> SearchFor(Expression<Func<IUser, bool>> predicate)
        {
            return _usersCollection.SearchFor(predicate);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(IUser entity)
        {
            _usersCollection.Update(entity);
        }
    }
}