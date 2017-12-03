using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers.LoginAndRegister
{
    [Route("")]
    public class LoginController : Controller
    {
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