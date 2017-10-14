namespace AuthService.Api.Controllers
{
    using System.Linq;
    using System.Net;

    using AuthService.Api.Dto.Request;
    using AuthService.Api.Dto.Response;
    using AuthService.Services;
    using AuthService.Services.Domain;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Swashbuckle.AspNetCore.SwaggerGen;

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
        [SwaggerResponse(
            (int)HttpStatusCode.OK,
            Description = "Registration complete",
            Type = typeof(RegistredUserResponseDto))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Registration fails")]
        public IActionResult RegisterUser(NewUserRegistrationRequest request)
        {
            if (ModelState.IsValid)
            {
                var users = _usersService.SearchFor(t => t.Email.ToLower().Trim() == request.Email.ToLower().Trim());
                if (users.Any() == false)
                {
                    var newUser = new User
                                      {
                                          Email = request.Email,
                                          Name = request.Name,
                                          PasswordHash = CryptoHelper.Crypto.HashPassword(request.Password)
                                      };

                    _usersService.Create(newUser);

                    return Ok(new RegistredUserResponseDto { Id = newUser.Id });
                }

                return BadRequest();
            }

            return BadRequest(ModelState);
        }
    }
}