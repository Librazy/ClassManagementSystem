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
    public class GroupController : Controller
    {

        public GroupController()
        { }

        public class GroupGrade
        {
            public struct PresentationGrade
            {
                public int TopicId { get; set; }
                public int Grade { get; set; }
            }

            public List<PresentationGrade> PresentationGrades { get; } = new List<PresentationGrade>();

            public int ReportGrade { get; set; }

            public int Grade { get; set; }
        }

        [HttpGet("/group/{groupId:long}")]
        public IActionResult GetGroupById(long groupId)
        {
            return Json(new Topic());
        }

        [HttpPut("/group/{groupId:long}")]
        public IActionResult UpdateGroupById(long groupId, [FromBody] Group updated)
        {
            return NoContent();
        }

        [HttpPost("/group/{groupId:long}/topic")]
        public IActionResult SelectTopic(long groupId, [FromBody] Topic selected)
        {
            return Created("/group/1/topic/1", new Dictionary<string, string> { ["url"] = " /group/1/topic/1" });
        }

        [HttpDelete("/group/{groupId:long}/topic/{topicId:long}")]
        public IActionResult DeselectTopic(long groupId, long topicId)
        {
            return NoContent();
        }

        [HttpGet("/group/{groupId:long}/grade")]
        public IActionResult GetGradeByGroupId(long groupId)
        {
            return Json(new GroupGrade());
        }

        [HttpPut("/group/{groupId:long}/grade")]
        public IActionResult UpdateGradeByGroupId(long groupId, GroupGrade updated)
        {
            return NoContent();
        }

        [HttpPut("/group/{groupId:long}/grade/{studentId:long}")]
        public IActionResult SubmitStudentGradeByGroupId(long groupId, long studentId, GroupGrade updated)
        {
            return NoContent();
        }
    }
}
