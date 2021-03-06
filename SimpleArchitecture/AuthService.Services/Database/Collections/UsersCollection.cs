﻿namespace AuthService.Services.Database.Collections
{
    using AuthService.Core.ConfigSections;
    using AuthService.Services.Domain;

    using Microsoft.Extensions.Options;

    /// <summary>
    /// The users collection.
    /// </summary>
    internal class UsersCollection : BaseRepository<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersCollection"/> class.
        /// </summary>
        /// <param name="databaseSettingsOptions">
        /// The database settings options.
        /// </param>
        public UsersCollection(IOptions<DatabaseSettings> databaseSettingsOptions)
            : base(databaseSettingsOptions)
        {
        }
    }
}