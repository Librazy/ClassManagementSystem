using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers.Teacher
{
    [Route("")]
    public class TeacherController : Controller
    {
        [Route("/TeacherHomePage")]
        public IActionResult TeacherHomePage()
        {
            return View();
        }

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

        [Route("/TeacherCreateClass")]
        public IActionResult TeacherCreateClass()
        {
            return View();
        }

        [Route("/TeacherSeminarInfo")]
        public IActionResult TeacherSeminarInfo()
        {
            return View("TeacherSenimarInfo");
        }

        [Route("/TeacherUpdateSeminar")]
        public IActionResult TeacherUpdateSeminar()
        {
            return View("TeacherUpdateSenimar");
        }

        [Route("/TeacherCreateSeminar")]
        public IActionResult TeacherCreateSeminar()
        {
            return View();
        }

        [Route("/TeacherTopicInfo")]
        public IActionResult TeacherTopicInfo()
        {
            return View();
        }

        [Route("/TeacherUpdateTopic")]
        public IActionResult TeacherUpdateTopic()
        {
            return View();
        }

        [Route("/TeacherCreateTopic")]
        public IActionResult TeacherCreateTopic()
        {
            return View();
        }
    }
}