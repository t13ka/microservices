namespace AuthService.Api.Dto.Request
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The get jwt token request.
    /// </summary>
    public class GetJwtTokenRequest
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
