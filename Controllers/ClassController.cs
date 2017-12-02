using System.Collections.Generic;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class ClassController : Controller
    {
        [HttpGet("/class")]
        public IActionResult GetUserClasses()
        {
            return Json(new List<Class>());
        }

        [HttpPost("/class")]
        public IActionResult CreateClass([FromBody] Class newClass)
        {
            return Created("/class/1", newClass);
        }

        [HttpGet("/class/{classId:long}")]
        public IActionResult GetClassById([FromRoute] long classId)
        {
            return Json(new Class(0));
        }

        [HttpDelete("/class/{classId:long}")]
        public IActionResult DeleteClassById([FromRoute] long classId)
        {
            return NoContent();
        }

        [HttpPut("/class/{classId:long}")]
        public IActionResult UpdateClassById([FromRoute] long classId, [FromBody] Class updated)
        {
            return NoContent();
        }

        [HttpGet("/class/{classId:long}/student")]
        public IActionResult GetStudentsByClassId([FromRoute] long classId)
        {
            return Json(new List<Class>());
        }

        [HttpPost("/class/{classId:long}/student")]
        public IActionResult SelectClass([FromRoute] long classId, [FromBody] User student)
        {
            return Created("/class/1/student/1", new Dictionary<string, string> {["url"] = " /class/1/student/1"});
        }

        [HttpDelete("/class/{classId:long}/student/{studentId:long}")]
        public IActionResult DeselectClass([FromRoute] long classId, [FromRoute] long studentId)
        {
            return NoContent();
        }

        [HttpGet("/class/{classId:long}/attendance")]
        public IActionResult GetAttendanceByClassId([FromRoute] long classId)
        {
            return Json(new List<Class>());
        }

        [HttpPut("/class/{classId:long}/attendance/{studentId:long}")]
        public IActionResult UpdateAttendanceByClassId([FromRoute] long classId, [FromRoute] long studentId,
            [FromBody] Location loc)
        {
            return NoContent();
        }

        [HttpGet("/class/{classId}/classgroup")]
        public IActionResult GetUserClassGroupByClassId([FromRoute] long classId)
        {
            return Json(new ClassGroup());
        }

        [HttpPut("/class/{classId}/classgroup")]
        public IActionResult UpdateUserClassGroupByClassId([FromRoute] long classId)
        {
            return NoContent();
        }

        public class Attendance
        {
            public int NumPresent { get; set; }
            public List<User> Present { get; set; }
            public List<User> Late { get; set; }
            public List<User> Absent { get; set; }
        }


        public struct Location
        {
            public double Longitude { get; set; }
            public double Latitude { get; set; }
            public double Elevation { get; set; }
        }

        public class ClassGroup
        {
        }
    }
}