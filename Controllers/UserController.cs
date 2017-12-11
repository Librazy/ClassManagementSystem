using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ClassManagementSystem.Controllers.Utils;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly CrmsContext _db;

        public UserController(CrmsContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpGet("/me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _db.Users.Include(u => u.School).SingleOrDefaultAsync(u => u.Id == User.Id());
            if (user == null)
            {
                return StatusCode(404, new { msg = "用户不存在" });
            }
            return Json(user, Ignoring("City", "Province"));
        }

        [HttpPut("/me")]
        public IActionResult UpdateCurrentUser([FromBody] User updated) => NoContent();

        [HttpGet("/signin")]
        public IActionResult SigninWechat([FromQuery] string code, [FromQuery] string state,
            [FromQuery(Name = "success_url")] string successUrl) => Json(new SigninResult());

        [HttpPost("/signin")]
        public IActionResult SigninPassword([FromBody] UsernameAndPassword uap)
        {
            var user = _db.Users.SingleOrDefault(u => u.Phone == uap.Phone);
            if (user == null)
            {
                return StatusCode(404, new {msg = "用户不存在"});
            }
            if (Utils.IsExpectedPassword(uap.Password, Utils.ReadHashString(user.Password)))
            {
                return Json(new SigninResult
                {
                    Exp = DateTime.UtcNow.AddDays(7)
                              .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks /
                          TimeSpan.TicksPerSecond,
                    Id = user.Id,
                    Type = user.Type,
                    Name = user.Name,
                    Jwt = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(Utils.JwtHeader,
                        new JwtPayload(
                            null,
                            null,
                            new[]
                            {
                                new Claim("id", user.Id.ToString()),
                                new Claim("type", user.Type.ToString().ToLower()),
                            },
                            null,
                            DateTime.Now.AddDays(7)
                        )))
                });
            }
            return StatusCode(401, new {msg = "用户名或密码错误"});
        }

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