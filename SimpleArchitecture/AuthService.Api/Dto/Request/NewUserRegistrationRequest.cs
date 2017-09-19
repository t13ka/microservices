namespace AuthService.Api.Dto.Request
{
    /// <summary>
    /// The new user registration request.
    /// </summary>
    public class NewUserRegistrationRequest
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}
