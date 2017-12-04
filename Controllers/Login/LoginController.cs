using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers.LoginAndRegister
{
    [Route("")]
    public class LoginController : Controller
    {
        [Route("/")]
        public IActionResult HomePage()
        {
            return Redirect("/Login");
        }

        [Route("/Login")]
        public IActionResult AccountLoginPage()
        {
            return View();
        }

        [Route("/RegisterPage")]
        public IActionResult RegisterPage()
        {
            return View();
        }
    }
}