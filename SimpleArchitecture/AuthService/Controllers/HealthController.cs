﻿using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// The health controller.
    /// </summary>
    [Route("/api/[controller]")]
    [AllowAnonymous]
    public class HealthController : Controller
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "I'm ok" });
        }
    }
}
