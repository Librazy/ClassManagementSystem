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
            var ta = new Topic(3)
            {
                Description = "Topic Topic A A",
                Name = "Topic A",
                GroupLimit = 3,
                GroupMemberLimit = 4,
                Serial = "A"
            };
            var tb = new Topic(3)
            {
                Description = "Topic Topic B B",
                Name = "Topic B",
                GroupLimit = 3,
                GroupMemberLimit = 4,
                Serial = "B"
            };
            var gs = new List<Group>
            {
                new Group(0)
                {
                    Name = "1A1",
                    Grade = new GroupGrade
                    {
                        Grade = 5,
                        PresentationGrades =
                        {
                            new GroupGrade.PresentationGrade {Grade = 4, TopicId = 3}
                        },
                        ReportGrade = 5
                    },
                    Members = new List<User>
                    {
                        new User(5324)
                        {
                            Name = "李四"
                        },
                        new User(5678)
                        {
                            Name = "王五"
                        }
                    },
                    Leader = new User(34) {Type = Models.User.UserType.Student, Name = "伊艾一"},
                    Topics = new List<Topic>
                    {
                        ta
                    },
                    Report = "/upload/report/0_3.pdf"
                },
                new Group(1)
                {
                    Name = "1A2",
                    Grade = new GroupGrade
                    {
                        Grade = 5,
                        PresentationGrades =
                        {
                            new GroupGrade.PresentationGrade {Grade = 5, TopicId = 3}
                        },
                        ReportGrade = 5
                    },
                    Members = new List<User>
                    {
                        new User(12324)
                        {
                            Name = "李有四"
                        },
                        new User(56783)
                        {
                            Name = "王我五"
                        }
                    },
                    Leader = new User(45) {Type = Models.User.UserType.Student, Name = "伊艾尔"},
                    Topics = new List<Topic>
                    {
                        ta
                    }
                },
                new Group(2)
                {
                    Name = "2B1",
                    Grade = new GroupGrade
                    {
                        Grade = 5,
                        PresentationGrades =
                        {
                            new GroupGrade.PresentationGrade {Grade = 4, TopicId = 5}
                        },
                        ReportGrade = 5
                    },
                    Leader = new User(435) {Type = Models.User.UserType.Student, Name = "贰碧一"},
                    Members = new List<User>
                    {
                        new User(25324)
                        {
                            Name = "李呃四"
                        },
                        new User(35678)
                        {
                            Name = "台王五"
                        }
                    },
                    Topics = new List<Topic>
                    {
                        tb
                    }
                }
            };
            return Json(gs[(int) groupId]);
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

        [HttpPut("/group/{groupId:long}/grade/report")]
        public IActionResult UpdateGradeByGroupId([FromRoute] long groupId, [FromBody] GroupGrade updated)
        {
            return NoContent();
        }

        [HttpPut("/group/{groupId:long}/grade/presentation/{studentId:long}")]
        public IActionResult SubmitStudentGradeByGroupId([FromBody] long groupId, [FromBody] long studentId,
            [FromBody] GroupGrade updated)
        {
            return NoContent();
        }
    }
}