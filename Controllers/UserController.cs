using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        [Authorize]
        [HttpGet("/me")]
        public IActionResult GetCurrentUser()
        {
            var u1 = new User(User.Id())
            {
                Phone = "18911114514",
                Name = "张三",
                Number = "23320152202333",
                Gender = Models.User.GenderType.Male,

                School = new School
                {
                    Name = "厦门市人民公园",
                    Province = "福建",
                    City = "厦门"
                },
                Email = "23320152202333@stu.xmu.edu.cn",
                Title = "本科",
                Avatar = "/upload/avatar/Logo_Li.png"
            };

            return Json(u1);
        }

        [HttpPut("/me")]
        public IActionResult UpdateCurrentUser([FromBody] User updated) => NoContent();

        [HttpGet("/signin")]
        public IActionResult SigninWechat([FromQuery] string code, [FromQuery] string state,
            [FromQuery(Name = "success_url")] string successUrl) => Json(new SigninResult());

        [HttpPost("/signin")]
        public IActionResult SigninPassword([FromBody] UsernameAndPassword uap) => Json(new SigninResult
        {
            Exp = DateTime.UtcNow.AddDays(7)
                .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks / TimeSpan.TicksPerSecond,
            Id = 1,
            Type = uap.Phone.EndsWith('1') ? "student" : "teacher",
            Name = "张三",
            Jwt = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(Utils.JwtHeader, new JwtPayload(
                null,
                null,
                new[]
                {
                    new Claim("id", "1"), 
                    new Claim("type", uap.Phone.EndsWith('1') ? "student" : "teacher"), 
                },
                null,
                DateTime.Now.AddDays(7)
            )))
        });

        [HttpPost("/register")]
        public IActionResult RegisterPassword([FromBody] UsernameAndPassword uap) => Json(new SigninResult());

        [HttpPost("/upload/avatar")]
        public IActionResult UploadAvatar(IFormFile file) =>
            Created("/upload/avatar.png", new {url = "/upload/avatar.png"});

        public class UsernameAndPassword
        {
            public string Phone { get; set; }
            public string Password { get; set; }
        }
    }
}