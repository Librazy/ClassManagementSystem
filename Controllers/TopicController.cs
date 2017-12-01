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
    public class TopicController : Controller
    {

        public TopicController()
        { }

        [HttpGet("/topic/{topicId:long}")]
        public IActionResult GetTopicById(long topicId)
        {
            return Json(new Topic());
        }

        [HttpDelete("/topic/{topicId:long}")]
        public IActionResult DeleteTopicById(long topicId)
        {
            return NoContent();
        }

        [HttpPut("/topic/{topicId:long}")]
        public IActionResult UpdateTopicById(long topicId, [FromBody] Topic updated)
        {
            return NoContent();
        }

        [HttpGet("/topic/{topicId:long}/group")]
        public IActionResult GetGroupsByTopicId(long topicId)
        {
            return Json(new List<Group>());
        }
    }
}
