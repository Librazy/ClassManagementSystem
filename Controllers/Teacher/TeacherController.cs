using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers.Teacher
{
    [Route("")]
    public class TeacherController : Controller
    {
        [Route("/TeacherCourseHomePage")]
        public IActionResult TeacherCourseHomePage()
        {
            return View();
        }

        [Route("/TeacherCourseInformation")]
        public IActionResult TeacherCourseInformation()
        {
            return View();
        }

        [Route("/TeacherClassInfo")]
        public IActionResult TeacherClassInfo()
        {
            return View();
        }

        [Route("/TeacherUpdateClass")]
        public IActionResult TeacherUpdateClass()
        {
            return View();
        }


        [Route("/TeacherSeminarInfo")]
        public IActionResult TeacherSeminarInfo()
        {
            return View("TeacherSenimarInfo");
        }
    }
}