﻿namespace AuthService.Api.Controllers
{
    using System.Net;

    using AuthService.Api.Dto.Response;
    using AuthService.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Swashbuckle.AspNetCore.SwaggerGen;

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
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Health", Type = typeof(HealthResponseDto))]
        public IActionResult Get()
        {
            // example:
            // _usersService.Create(new User { _id = Guid.NewGuid().ToString(), Email = "test@mail.com", Name = "tester" });
            // var result = _usersService.SearchFor(t => t._id == "97db11fd-29cf-4398-9a97-fce60e503f0d");
            return Ok(new HealthResponseDto { Message = "I'm ok" });
        }
    }
}