namespace AuthService.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using AuthService.Services.Domain;

    /// <summary>
    /// The UserService interface.
    /// </summary>
    public interface IUsersService
    {
        long Count();

        void Create(User entity);

        void Delete(long id);

        IList<User> GetAll();

        User GetById(long id);

        void Replace(User entity);

        IList<User> SearchFor(Expression<Func<User, bool>> predicate);

        void Update(User entity);
    }
}