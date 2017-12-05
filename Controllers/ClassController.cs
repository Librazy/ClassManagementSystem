using System.Collections.Generic;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using static ClassManagementSystem.Controllers.Util;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class ClassController : Controller
    {
        [HttpGet("/class")]
        public IActionResult GetUserClasses()
        {
            var c1 = new Class(23)
            {
                Name= "周三1-2节",
                Site="公寓405",
                CourseName="OOAD",
                
                Teacher="邱明",
                Time= "周三1-2、周五1-2"  
            };
            var c2 = new Class(42)
            {
                Name = "一班",
                Site = "海韵202",
                CourseName= ".Net 平台开发",
                Teacher="杨律青",
                Time = "周三34节 周五12节"
            };
            return Json(new List<Class> {c1, c2}, Ignoring("Id", "Calling", "NumStudent", "Students", "Proportions"));
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