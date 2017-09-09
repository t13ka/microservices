namespace AuthService.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using AuthService.Core;
    using AuthService.Core.ConfigSections;

    using Microsoft.Extensions.Options;

    using MongoDB.Bson;
    using MongoDB.Driver;

    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="T">
    /// Type of current entity
    /// </typeparam>
    public class BaseRepository<T> : IRepository<T>
        where T : IEntity
    {
        /// <summary>
        /// The _collection.
        /// </summary>
        private readonly IMongoCollection<T> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="databaseSettingsOptions">
        /// The database Settings Options.
        /// </param>
        protected BaseRepository(IOptions<DatabaseSettings> databaseSettingsOptions)
        {
            var databaseSettings = databaseSettingsOptions.Value;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }

        /// <summary>
        /// The count.
        /// </summary>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        public virtual long Count()
        {
            return _collection.Count(new BsonDocument());
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Create(T entity)
        {
            _collection.InsertOne(entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public virtual void Delete(string id)
        {
            _collection.DeleteOne(t => t._id == id);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public virtual IList<T> GetAll()
        {
            return _collection.FindSync(new BsonDocument()).ToList();
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public virtual T GetById(string id)
        {
            return _collection.FindSync(t => t._id == id).ToEnumerable().FirstOrDefault();
        }

        /// <summary>
        /// The replace.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Replace(T entity)
        {
            _collection.ReplaceOne(t => t._id == entity._id, entity);
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
        public virtual IList<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            var r = _collection.AsQueryable().Where(predicate.Compile()).ToList();
            return r;
        }

        /// <summary>
        /// To update specific property(ies) you must override this method
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            _collection.ReplaceOne(t => t._id == entity._id, entity);
        }
    }
}