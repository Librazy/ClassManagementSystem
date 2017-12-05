using System.Collections.Generic;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class SeminarController : Controller
    {
        [HttpGet("/seminar/{seminarId:long}/fixed")]
        public IActionResult GetSeminarByIdFixed([FromRoute] long seminarId)
        {
            var s1 = new Seminar(29)
            {
                Name = "界面原型设计",
                Description = "界面原型设计",
                StartTime = "2017-09-25",
                EndTime = "2017-10-09",
                Topics = new List<Topic>()
                {
                    new Topic()
                    {
                        Name = "界面原型设计"
                    }
                }
            };
            return Json(s1);
        }

        [HttpGet("/seminar/{seminarId:long}/random")]
        public IActionResult GetSeminarByIdRandom([FromRoute] long seminarId)
        {
            var s1 = new Seminar(32)
            {
                Name = "概要设计",
                Description = "模型层与数据库设计",
                StartTime = "2017-10-10",
                EndTime = "2017-10-24",
                Topics = new List<Topic>()
                {
                    new Topic()
                    {
                        Name = "领域模型与模块"
                    }
                }
            };
            return Json(s1);
        }

        [HttpDelete("/seminar/{seminarId:long}")]
        public IActionResult DeleteSeminarById([FromRoute] long seminarId)
        {
            return NoContent();
        }

        [HttpPut("/seminar/{seminarId:long}")]
        public IActionResult UpdateSeminarById([FromRoute] long seminarId, [FromBody] Seminar updated)
        {
            return NoContent();
        }

        [HttpGet("/seminar/{seminarId:long}/topic")]
        public IActionResult GetTopicsBySeminarId([FromRoute] long seminarId)
        {
            return Json(new List<Topic>());
        }

        [HttpPut("/seminar/{seminarId:long}/topic")]
        public IActionResult CreateTopicBySeminarId([FromRoute] long seminarId, [FromBody] Seminar newSeminar)
        {
            return Created("/topic/1", newSeminar);
        }

        [HttpGet("/seminar/{seminarId:long}/group")]
        public IActionResult GetGroupsBySeminarId([FromRoute] long seminarId)
        {
            return Json(new List<Group>());
        }
    }
}