namespace AuthService.Api.Controllers
{
    using AuthService.Api.Dto.Request;
    using AuthService.Services;
    using AuthService.Services.Domain;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The registration controller.
    /// </summary>
    [Route("/api/[controller]")]
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        private readonly IUsersService _usersService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationController"/> class.
        /// </summary>
        /// <param name="usersService">
        /// The users service.
        /// </param>
        public RegistrationController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public IActionResult RegisterUser(NewUserRegistrationRequest request)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                                  {
                                      Email = request.Email,
                                      Name = request.Name,
                                      PasswordHash = CryptoHelper.Crypto.HashPassword(request.Password)
                                  };

                // todo: generate hash
                _usersService.Create(newUser);

                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}