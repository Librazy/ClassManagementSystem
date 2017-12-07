using System;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Http;
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
            var u1 = new User(3486)
            {
                Phone = "18911114514",
                Name = "张三",
                Number = "23320152202333",
                Gender = "male",

                School = new School
                {
                    Name = "厦门市人民公园",
                    Province = "福建",
                    City = "厦门"
                },
                Email = "23320152202333@stu.xmu.edu.cn",
                Title = "本科"
            };

            return Json(u1);
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
            return Json(new SigninResult
            {
                Exp = DateTime.UtcNow.AddDays(7)
                    .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Seconds,
                Id = 1,
                Type = uap.Phone.EndsWith('1') ? "student" : "teacher",
                Name = "张三"
            });
        }

        [HttpPost("/register")]
        public IActionResult RegisterPassword([FromBody] UsernameAndPassword uap)
        {
            return Json(new SigninResult());
        }

        [HttpPost("/upload/avatar")]
        public IActionResult UploadAvatar(IFormFile file)
        {
            return Created("/upload/avatar.png", new {url = "/upload/avatar.png"});
        }

        public class UsernameAndPassword
        {
            public string Phone { get; set; }
            public string Password { get; set; }
        }
    }
}