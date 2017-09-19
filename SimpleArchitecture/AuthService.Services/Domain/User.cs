namespace AuthService.Services.Domain
{
    using AuthService.Core;
    using AuthService.Services.Database;

    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// The user.
    /// </summary>
    public class User : IEntity
    {
        [BsonId(IdGenerator = typeof(AutoIncrementIdGenerator<User>), Order = 0)]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
