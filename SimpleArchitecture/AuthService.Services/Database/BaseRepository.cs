namespace AuthService.Services.Database
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
    internal class BaseRepository<T> : IRepository<T>
        where T : IEntity
    {
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
            var type = typeof(T);
            var finalCollectionName = type.Name.ToLower() + "s";
            _collection = database.GetCollection<T>(finalCollectionName);
        }

        public virtual long Count()
        {
            return _collection.Count(new BsonDocument());
        }

        public virtual void Create(T entity)
        {
            _collection.InsertOne(entity);
        }

        public virtual void Delete(long id)
        {
            _collection.DeleteOne(t => t.Id == id);
        }

        public virtual IList<T> GetAll()
        {
            return _collection.FindSync(new BsonDocument()).ToList();
        }

        public virtual T GetById(long id)
        {
            return _collection.FindSync(t => t.Id == id).ToEnumerable().FirstOrDefault();
        }

        public virtual void Replace(T entity)
        {
            _collection.ReplaceOne(t => t.Id == entity.Id, entity);
        }

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
            _collection.ReplaceOne(t => t.Id == entity.Id, entity);
        }
    }
}