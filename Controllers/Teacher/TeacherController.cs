using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers.Teacher
{
    [Route("")]
    public class TeacherController : Controller
    {
        [Route("/Teacher")]
        public IActionResult TeacherHomePage()
        {
            return View();
        }

        [Route("/Teacher/Modify")]
        public IActionResult TeacherInfoModifyPage()
        {
            return View();
        }

        [Route("/Teacher/Course")]
        public IActionResult TeacherCourseHomePage()
        {
            return View();
        }

        [Route("/Teacher/Course/Courseinfo")]
        public IActionResult TeacherCourseInformation()
        {
            return View();
        }

        [Route("/Teacher/Class")]
        public IActionResult TeacherClassInfo()
        {
            return View();
        }

        [Route("/Teacher/Class/Modify")]
        public IActionResult TeacherUpdateClass()
        {
            return View();
        }

        [Route("/Teacher/Class/Create")]
        public IActionResult TeacherCreateClass()
        {
            return View();
        }

        [Route("/Teacher/Seminar")]
        public IActionResult TeacherSeminarInfo()
        {
            return View("TeacherSenimarInfo");
        }

        [Route("/Teacher/Seminar/Update")]
        public IActionResult TeacherUpdateSeminar()
        {
            return View("TeacherUpdateSenimar");
        }

        [Route("/Teacher/Seminar/Create")]
        public IActionResult TeacherCreateSeminar()
        {
            return View();
        }

        [Route("/Teacher/Topic")]
        public IActionResult TeacherTopicInfo()
        {
            return View();
        }

        [Route("/Teacher/Topic/Update")]
        public IActionResult TeacherUpdateTopic()
        {
            return View();
        }

        [Route("/Teacher/Topic/Create")]
        public IActionResult TeacherCreateTopic()
        {
            return View();
        }

        [Route("/Teacher/Seminar/Score")]
        public IActionResult TeacherScoreHome()
        {
            return View();
        }

        [Route("/Teacher/Seminar/GroupReport")]
        public IActionResult TeacherScoreReportPage()
        {
            return View();
        }
    }
}