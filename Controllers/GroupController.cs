using System.Collections.Generic;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class GroupController : Controller
    {
        [HttpGet("/group/{groupId:long}")]
        public IActionResult GetGroupById([FromRoute] long groupId)
        {
            var g1 = new Group()
            {
                GroupOrder="3A2",
                Leader = new User(8888)
                {
                    Name = "张三"
                },
                Members = new List<User>()
                {
                    new User(5324)
                    {
                        Name = "李四"
                    },
                    new User(5678)
                    {
                        Name= "王五"
                    }
                },
                Topics =new List<Topic>()
                {
                    new Topic(257)
                    {
                        Name= "领域模型与模块"
                    }
                },
                Report=""
            };
            return Json(g1);
        }

        [HttpPut("/group/{groupId:long}")]
        public IActionResult UpdateGroupById([FromRoute] long groupId, [FromBody] Group updated)
        {
            return NoContent();
        }

        [HttpPost("/group/{groupId:long}/topic")]
        public IActionResult SelectTopic([FromRoute] long groupId, [FromBody] Topic selected)
        {
            return Created("/group/1/topic/1", new Dictionary<string, string> {["url"] = " /group/1/topic/1"});
        }

        [HttpDelete("/group/{groupId:long}/topic/{topicId:long}")]
        public IActionResult DeselectTopic([FromRoute] long groupId, [FromRoute] long topicId)
        {
            return NoContent();
        }

        [HttpGet("/group/{groupId:long}/grade")]
        public IActionResult GetGradeByGroupId([FromRoute] long groupId)
        {
            return Json(new GroupGrade());
        }

        [HttpPut("/group/{groupId:long}/grade")]
        public IActionResult UpdateGradeByGroupId([FromRoute] long groupId, [FromBody] GroupGrade updated)
        {
            return NoContent();
        }

        [HttpPut("/group/{groupId:long}/grade/{studentId:long}")]
        public IActionResult SubmitStudentGradeByGroupId([FromBody] long groupId, [FromBody] long studentId,
            [FromBody] GroupGrade updated)
        {
            return NoContent();
        }
    }
}