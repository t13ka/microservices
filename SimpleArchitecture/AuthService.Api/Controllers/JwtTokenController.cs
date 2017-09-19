namespace AuthService.Api.Controllers
{
    using AuthService.Api.Dto.Request;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The jwt token controller.
    /// </summary>
    [Route("/api/[controller]")]
    [AllowAnonymous]
    public class JwtTokenController : Controller
    {
        [HttpGet]
        public IActionResult Get(GetJwtTokenRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}