using System;

namespace AuthService.Services
{
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using AuthService.Core.ConfigSections;
    using AuthService.Services.Database.Collections;
    using AuthService.Services.Domain;

    using Microsoft.Extensions.Options;

    /// <summary>
    /// The users service.
    /// </summary>
    public class UsersService : IUsersService
    {
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

        public long Count()
        {
            return _usersCollection.Count();
        }

        public void Create(User entity)
        {
            _usersCollection.Create(entity);
        }

        public void Delete(long id)
        {
            _usersCollection.Delete(id);
        }

        public IList<User> GetAll()
        {
            return _usersCollection.GetAll();
        }

        public User GetById(long id)
        {
            return _usersCollection.GetById(id);
        }

        public void Replace(User entity)
        {
            _usersCollection.Replace(entity);
        }

        public IList<User> SearchFor(Expression<Func<User, bool>> predicate)
        {
            return _usersCollection.SearchFor(predicate);
        }

        public void Update(User entity)
        {
            _usersCollection.Update(entity);
        }
    }
}