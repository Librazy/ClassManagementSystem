using System.Collections.Generic;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using static ClassManagementSystem.Controllers.Util;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class CourseController : Controller
    {
        [HttpGet("/course")]
        public IActionResult GetUserCourses()
        {
            var c1 = new Course(1)
            {
                Name = "OOAD",
                Description = "Description",
                EndTime = "2017-12-31",
                StartTime = "2017-10-01"
            };
            var c2 = new Course(2)
            {
                Name = "J2EE",
                Description = "Description",
                EndTime = "2017-12-31",
                StartTime = "2017-10-01"
            };
            return Json(new List<Course> { c1, c2 }, Ignoring("Classes", "Proportions", "TeacherName", "Teacher", "TeacherEmail", "Seminars"));
        }

        [HttpPost("/course")]
        public IActionResult CreateCourse([FromBody] Course newCourse)
        {
            return Created("/course/1", newCourse);
        }

        [HttpGet("/course/{courseId:long}")]
        public IActionResult GetCourseById([FromRoute] long courseId)
        {
            return Json(new Course(0), Ignoring("Classes", "Proportions", "Teacher", "Seminars"));
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
            var c1 = new Class(1)
            {
                Name = "周三1-2"
            };
            var c2 = new Class(1)
            {
                Name = "周三910"
            };
            return Json(new List<Class>{c1, c2});
        }

        [HttpPost("/course/{courseId:long}/class")]
        public IActionResult CreateClassByCourseId([FromRoute] long courseId, [FromBody] Class newClass)
        {
            return Created("/course/1", newClass);
        }

        [HttpGet("/course/{courseId:long}/seminar")]
        public IActionResult GetSeminarsByCourseId([FromRoute] long courseId)
        {
            var s1 = new Seminar(29)
            {
                Name = "界面原型设计",
                Description = "界面原型设计",
                GroupingMethod = "fixed",
                StartTime = "2017-09-25",
                EndTime = "2017-10-09",
            };
            var s2 = new Seminar(32)
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
            return Created("/course/1", newSeminar);
        }
    }
}