using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassManagementSystem.Models;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    public class UserController : Controller
    {
        public class UsernameAndPassword {
            public string Phone { get; set; }
            public string Password { get; set; }
        }

        public UserController()
        { }

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
        public IActionResult SigninWechat([FromQuery] string code, [FromQuery] string state, [FromQuery(Name = "success_url")] string successUrl)
        {
            return Json(new Jwt());
        }

        [HttpPost("/signin")]
        public IActionResult SigninPassword([FromBody] UsernameAndPassword uap)
        {
            return Json(new Jwt());
        }

        [HttpPost("/register")]
        public IActionResult RegisterPassword([FromBody] UsernameAndPassword uap)
        {
            return Json(new Jwt());
        }
    }
}
