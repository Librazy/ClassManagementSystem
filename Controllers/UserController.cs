using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        [HttpGet("/me")]
        public IActionResult GetCurrentUser()
        {
            return Json(new User(0));
        }

        [HttpPut("/me")]
        public IActionResult UpdateCurrentUser([FromBody] User updated)
        {
            return NoContent();
        }

        [HttpGet("/signin")]
        public IActionResult SigninWechat([FromQuery] string code, [FromQuery] string state,
            [FromQuery(Name = "success_url")] string successUrl)
        {
            return Json(new SigninResult());
        }

        [HttpPost("/signin")]
        public IActionResult SigninPassword([FromBody] UsernameAndPassword uap)
        {
            return Json(new SigninResult());
        }

        [HttpPost("/register")]
        public IActionResult RegisterPassword([FromBody] UsernameAndPassword uap)
        {
            return Json(new SigninResult());
        }

        public class UsernameAndPassword
        {
            public string Phone { get; set; }
            public string Password { get; set; }
        }
    }
}