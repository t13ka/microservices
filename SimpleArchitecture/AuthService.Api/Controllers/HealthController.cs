namespace AuthService.Api.Controllers
{
    using System;

    using AuthService.Core;
    using AuthService.Services.Database;
    using AuthService.Services.Domain;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The health controller.
    /// </summary>
    [Route("/api/[controller]")]
    [AllowAnonymous]
    public class HealthController : Controller
    {
        /// <summary>
        /// The users service.
        /// </summary>
        private readonly IUsersService _usersService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthController"/> class.
        /// </summary>
        /// <param name="usersService">
        /// The user service.
        /// </param>
        public HealthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            // example:
            // _usersService.Create(new User { _id = Guid.NewGuid().ToString(), Email = "test@mail.com", Name = "tester" });
            // var result = _usersService.SearchFor(t => t._id == "97db11fd-29cf-4398-9a97-fce60e503f0d");
            return Ok(new { Message = "I'm ok" });
        }
    }
}