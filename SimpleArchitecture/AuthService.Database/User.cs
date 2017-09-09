namespace AuthService.Database
{
    using AuthService.Core;

    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    /// The user.
    /// </summary>
    public class User : IUser
    {
        /// <summary>
        /// Gets or sets the _id.
        /// </summary>
        [BsonId]
        public string _id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        public string PasswordHash { get; set; }
    }
}
