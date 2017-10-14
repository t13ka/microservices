namespace AuthService.Services.Database
{
    using System;
    using System.Linq;
    using System.Threading;

    using AuthService.Core;

    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;

    /// <summary>
    /// The auto increment id generator.
    /// </summary>
    /// <typeparam name="T">
    /// Type of Entity
    /// </typeparam>
    public class AutoIncrementIdGenerator<T> : IIdGenerator
        where T : IEntity
    {
        private static long Counter;

        public static object Locker = new object();

        public object GenerateId(object container, object document)
        {
            var collection = (IMongoCollection<T>)container;

            try
            {
                Monitor.Enter(Locker);

                var lastLastOrDefault = collection.AsQueryable().OrderByDescending(t => t.Id).FirstOrDefault();
                if (lastLastOrDefault != null)
                {
                    Counter = lastLastOrDefault.Id;
                    Counter++;
                }
                else
                {
                    Counter++;
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                Monitor.Exit(Locker);
            }

            return Counter;
        }
        
        public bool IsEmpty(object id)
        {
            var d = default(long).ToString();
            var value = id.ToString();

            if (d == value)
            {
                return true;
            }

            return false;
        }
    }
}