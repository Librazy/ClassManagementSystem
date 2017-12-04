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
    }
}