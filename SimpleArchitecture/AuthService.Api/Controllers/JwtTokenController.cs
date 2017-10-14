namespace AuthService.Api.Controllers
{
    using System.Linq;
    using System.Net;

    using AuthService.Api.Dto.Request;
    using AuthService.Api.Dto.Response;
    using AuthService.Services;
    using AuthService.Services.Utils;

    using CryptoHelper;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// The jwt token controller.
    /// </summary>
    [Route("/api/[controller]")]
    [AllowAnonymous]
    public class JwtTokenController : Controller
    {
        private readonly IUsersService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtTokenController"/> class.
        /// </summary>
        /// <param name="userService">
        /// The user service.
        /// </param>
        public JwtTokenController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Jwt token created", Type = typeof(TokenResponseDto))]
        public IActionResult Get(GetJwtTokenRequest request)
        {
            if (ModelState.IsValid)
            {
                var users = _userService.SearchFor(t => t.Email == request.Email);
                if (users.Any())
                {
                    var user = users.First();

                    if (Crypto.VerifyHashedPassword(user.PasswordHash, request.Password))
                    {
                        var identity = JwtUtils.GetIdentity(user);
                        var token = JwtUtils.GenerateWriterJwtToken(identity);
                        return Ok(new TokenResponseDto { AccessToken = token });
                    }
                }

                return BadRequest();
            }

            return BadRequest(ModelState);
        }
    }
}