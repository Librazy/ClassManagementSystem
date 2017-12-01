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
    public class SchoolController : Controller
    {
        public SchoolController()
        { }

        [HttpGet("/school")]
        public IActionResult GetSchools()
        {
            return Json(new List<School>());
        }

        [HttpGet("/school/{schoolId:long}")]
        public IActionResult GetSchoolById(long schoolId)
        {
            return Json(new School());
        }

        [HttpPost("/school")]
        public IActionResult CreateSchool(School newSchool)
        {
            return Created("/school/1", newSchool);
        }
    }
}
