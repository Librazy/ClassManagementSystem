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
            return Json(new List<Course> {c1 , c2}, Ignoring("Classes", "Proportions"));
        }

        [HttpPost("/course")]
        public IActionResult CreateCourse([FromBody] Course newCourse)
        {
            return Created("/course/1", newCourse);
        }

        [HttpGet("/course/{courseId:long}")]
        public IActionResult GetCourseById([FromRoute] long courseId)
        {
            return Json(new Course(0));
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
            return Json(new List<Class>());
        }

        [HttpPost("/course/{courseId:long}/class")]
        public IActionResult CreateClassByCourseId([FromRoute] long courseId, [FromBody] Class newClass)
        {
            return Created("/course/1", newClass);
        }

        [HttpGet("/course/{courseId:long}/seminar")]
        public IActionResult GetSeminarsByCourseId([FromRoute] long courseId)
        {
            return Json(new List<Class>());
        }

        [HttpPost("/course/{courseId:long}/seminar")]
        public IActionResult CreateSeminarByCourseId([FromRoute] long courseId, [FromBody] Seminar newSeminar)
        {
            return Created("/course/1", newSeminar);
        }
    }
}