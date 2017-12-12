using System.Collections.Generic;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using static ClassManagementSystem.Controllers.Utils;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class CourseController : Controller
    {
        [HttpGet("/course")]
        public IActionResult GetUserCourses()
        {
            var c1 = new Course
            {
                Name = "OOAD",
                Description = "Description",
                EndTime = "2017-12-31",
                StartTime = "2017-10-01",
                Classes = new List<Class> { new Class(), new Class(), new Class() }
            };
            var c2 = new Course
            {
                Name = "J2EE",
                Description = "Description",
                EndTime = "2017-12-31",
                StartTime = "2017-10-01",
                Classes = new List<Class> { new Class(), new Class() }
            };
            return Json(new List<Course> { c1, c2 }, Ignoring("Classes", "Proportions", "TeacherName", "Teacher", "TeacherEmail", "Seminars"));
        }

        [HttpPost("/course")]
        public IActionResult CreateCourse([FromBody] Course newCourse)
        {
            return Created("/course/1", new {id = 1});
        }

        [HttpGet("/course/{courseId:long}")]
        public IActionResult GetCourseById([FromRoute] long courseId)
        {
            var c1 = new Course
            {
                Name = "OOAD",
                Description = "Description",
                EndTime = "2018-1-15",
                StartTime = "2017-10-01",
                Classes = new List<Class> { new Class(), new Class(), new Class() }
            };
            var c2 = new Course
            {
                Name = "J2EE",
                Description = "Description",
                EndTime = "2017-12-31",
                StartTime = "2017-10-01",
                Classes = new List<Class> { new Class(), new Class() }
            };
            return Json(courseId == 0 ? c1 : c2, Ignoring("Classes", "Proportions", "Teacher", "Seminars"));
        }

        [HttpDelete("/course/{courseId:long}")]
        public IActionResult DeleteCourseById([FromRoute] long courseId)
        {
            return NoContent();
        }

        [HttpPut("/course/{courseId:long}")]
        public IActionResult UpdateCourseById([FromRoute] long courseId, [FromBody] Course updated)
        {
            return NoContent();
        }

        [HttpGet("/course/{courseId:long}/class")]
        public IActionResult GetClassesByCourseId([FromRoute] long courseId)
        {
            var c1 = new Class
            {
                Name = "周三1-2"
            };
            var c2 = new Class
            {
                Name = "周三910"
            };
            return Json(new List<Class>{c1, c2});
        }

        [HttpPost("/course/{courseId:long}/class")]
        public IActionResult CreateClassByCourseId([FromRoute] long courseId, [FromBody] Class newClass)
        {
            return Created("/class/1", new { id = 1 });
        }

        [HttpGet("/course/{courseId:long}/seminar")]
        public IActionResult GetSeminarsByCourseId([FromRoute] long courseId)
        {
            var s1 = new Seminar
            {
                Name = "界面原型设计",
                Description = "界面原型设计",
                GroupingMethod = "fixed",
                StartTime = "2017-09-25",
                EndTime = "2017-10-09",
            };
            var s2 = new Seminar
            {
                Name = "概要设计",
                Description = "模型层与数据库设计",
                GroupingMethod = "random",
                StartTime = "2017-10-10",
                EndTime = "2017-10-24"
            };
            return Json(new List<Seminar>{s1, s2});
        }

        [HttpPost("/course/{courseId:long}/seminar")]
        public IActionResult CreateSeminarByCourseId([FromRoute] long courseId, [FromBody] Seminar newSeminar)
        {
            return Created("/seminar/1", new { id = 1 });
        }

        [HttpGet("/course/{courseId:long}/grade")]
        public IActionResult GetGradeByCourseId([FromRoute] long courseId)
        {
            var gd1 = new Grade
            {
                SeminarName="需求分析",
                GroupName="3A2",
                LeaderName="张三",
                PresentationGrade=3,
                ReportGrade=4,
                FinalGrade=4
            };
            var gd2 = new Grade
            {
                SeminarName="界面原型设计",
                GroupName="3A3",
                LeaderName="张三",
                PresentationGrade=4,
                ReportGrade=4,
                FinalGrade=4
            };
            return Json(new List<Grade> {gd1, gd2});
        }
    }
}