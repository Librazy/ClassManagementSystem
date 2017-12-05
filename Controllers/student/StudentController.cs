using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    public class StudentController : Controller
    {
        [Route("/Student/")]
        public IActionResult StudentHomePage()
        {
            return View();
        }

        [Route("/Student/Course")]
        public IActionResult StudentCourseHome()
        {
            return View();
        }

        [Route("Student/Choosecourse")]
        public IActionResult StudentChooseCoursePage()
        {
            return View();
        }

        [Route("Student/Course/Courseinfo")]
        public IActionResult StudentCourseInformation()
        {
            return View();
        }

        [Route("Student/Seminar/Fixed")]
        public IActionResult StudentSeminarPageFixed()
        {
            return View();
        }

        [Route("Student/Seminar/Random")]
        public IActionResult StudentSeminarPageRandom()
        {
            return View();
        }

        [Route("Student/Course/Managegroup")]
        public IActionResult StudentModifyGroupPage()
        {
            return View();
        }

    }
}