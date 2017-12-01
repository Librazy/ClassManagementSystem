using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassManagementSystem.Models;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class CourseController : Controller
    {

        public CourseController()
        { }

        [HttpGet("/course")]
        public IActionResult GetUserCourses()
        {
            return Json(new List<Course>());
        }

        [HttpPost("/course")]
        public IActionResult CreateCourse([FromBody] Course newCourse)
        {
            return Created("/course/1", newCourse);
        }

        [HttpGet("/course/{courseId:long}")]
        public IActionResult GetCourseById(long courseId)
        {
            return Json(new Course(0));
        }

        [HttpDelete("/course/{courseId:long}")]
        public IActionResult DeleteCourseById(long courseId)
        {
            return NoContent();
        }

        [HttpPut("/course/{courseId:long}")]
        public IActionResult UpdateCourseById(long courseId, [FromBody] Course updated)
        {
            return NoContent();
        }

        [HttpGet("/course/{courseId:long}/class")]
        public IActionResult GetClassesByCourseId(long courseId)
        {
            return Json(new List<Class>());
        }

        [HttpPost("/course/{courseId:long}/class")]
        public IActionResult CreateClassByCourseId(long courseId, [FromBody] Class newClass)
        {
            return Created("/course/1", newClass);
        }

        [HttpGet("/course/{courseId:long}/seminar")]
        public IActionResult GetSeminarsByCourseId(long courseId)
        {
            return Json(new List<Class>());
        }

        [HttpPost("/course/{courseId:long}/seminar")]
        public IActionResult CreateSeminarByCourseId(long courseId, [FromBody] Seminar newSeminar)
        {
            return Created("/course/1", newSeminar);
        }
    }
}
