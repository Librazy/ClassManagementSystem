using System.Collections.Generic;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class TopicController : Controller
    {
        [HttpGet("/topic/{topicId:long}")]
        public IActionResult GetTopicById([FromRoute] long topicId)
        {
            return Json(new Topic());
        }

        [HttpDelete("/topic/{topicId:long}")]
        public IActionResult DeleteTopicById([FromRoute] long topicId)
        {
            return NoContent();
        }

        [HttpPut("/topic/{topicId:long}")]
        public IActionResult UpdateTopicById([FromRoute] long topicId, [FromBody] Topic updated)
        {
            return NoContent();
        }

        [HttpGet("/topic/{topicId:long}/group")]
        public IActionResult GetGroupsByTopicId([FromRoute] long topicId)
        {
            return Json(new List<Group>());
        }
    }
}