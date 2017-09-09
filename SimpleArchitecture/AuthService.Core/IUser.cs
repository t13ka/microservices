namespace AuthService.Core
{
    /// <summary>
    /// The User interface.
    /// </summary>
    public interface IUser : IEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        string PasswordHash { get; set; }
    }
}