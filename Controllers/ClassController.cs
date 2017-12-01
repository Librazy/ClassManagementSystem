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
    public class ClassController : Controller
    {

        public ClassController()
        { }

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
        public IActionResult GetClassById(long classId)
        {
            return Json(new Class(0));
        }

        [HttpDelete("/class/{classId:long}")]
        public IActionResult DeleteClassById(long classId)
        {
            return NoContent();
        }

        [HttpPut("/class/{classId:long}")]
        public IActionResult UpdateClassById(long classId, [FromBody] Class updated)
        {
            return NoContent();
        }

        [HttpGet("/class/{classId:long}/student")]
        public IActionResult GetStudentsByClassId(long classId)
        {
            return Json(new List<Class>());
        }

        [HttpPost("/class/{classId:long}/student")]
        public IActionResult SelectClass(long classId, [FromBody] User student)
        {
            return Created("/class/1/student/1", new Dictionary<string, string> { ["url"] = " /class/1/student/1"});
        }

        [HttpDelete("/class/{classId:long}/student/{studentId:long}")]
        public IActionResult DeselectClass(long classId, long studentId)
        {
            return NoContent();
        }

        [HttpGet("/class/{classId:long}/attendance")]
        public IActionResult GetAttendanceByClassId(long classId)
        {
            return Json(new List<Class>());
        }

        [HttpPut("/class/{classId:long}/attendance/{studentId:long}")]
        public IActionResult UpdateAttendanceByClassId(long classId, long studentId, [FromBody] Location loc)
        {
            return NoContent();
        }

        [HttpGet("/class/{classId}/classgroup")]
        public IActionResult GetUserClassGroupByClassId(long classId)
        {
            return Json(new ClassGroup());
        }

        [HttpPut("/class/{classId}/classgroup")]
        public IActionResult UpdateUserClassGroupByClassId(long classId)
        {
            return NoContent();
        }
    }
}
