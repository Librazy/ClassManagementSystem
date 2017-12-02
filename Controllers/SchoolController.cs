using System.Collections.Generic;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class SchoolController : Controller
    {
        [HttpGet("/school")]
        public IActionResult GetSchools([FromQuery] string city)
        {
            return Json(new List<School>());
        }

        [HttpGet("/school/{schoolId:long}")]
        public IActionResult GetSchoolById([FromRoute] long schoolId)
        {
            return Json(new School());
        }

        [HttpPost("/school")]
        public IActionResult CreateSchool([FromBody] School newSchool)
        {
            return Created("/school/1", newSchool);
        }
    }
}