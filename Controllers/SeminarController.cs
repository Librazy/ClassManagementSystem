using System.Collections.Generic;
using ClassManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using static ClassManagementSystem.Controllers.Util;

namespace ClassManagementSystem.Controllers
{
    [Route("")]
    [Produces("application/json")]
    public class SeminarController : Controller
    {
        [HttpGet("/seminar/{seminarId:long}")]
        public IActionResult GetSeminarByIdRandom([FromRoute] long seminarId)
        {
            var s1 = new Seminar(32)
            {
                Name = "概要设计",
                Description = "模型层与数据库设计",
                StartTime = "2017-10-10",
                EndTime = "2017-10-24",
                Topics = new List<Topic>
                {
                    new Topic(257)
                    {
                        Name = "领域模型与模块"
                    }
                }
            };
            var s2 = new Seminar(29)
            {
                Name = "界面原型设计",
                Description = "界面原型设计",
                StartTime = "2017-09-25",
                EndTime = "2017-10-09",
                Topics = new List<Topic>
                {
                    new Topic(344)
                    {
                        Name = "界面原型设计"
                    }
                }
            };
            return Json(seminarId == 1 ? s2 : s1);
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
            var ta = new Topic(3)
            {
                Description = "Topic Topic A A",
                Name = "Topic A",
                GroupLimit = 3,
                GroupMemberLimit = 4,
                Serial = "A"
            };
            var tb = new Topic(5)
            {
                Description = "Topic Topic B B",
                Name = "Topic B",
                GroupLimit = 3,
                GroupMemberLimit = 4,
                Serial = "B"
            };
            return Json(new List<Group>
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
                    Topics = new List<Topic>
                    {
                        tb
                    }
                }
            }, Ignoring("Group*", "Members", "Leader", "Report", "Grade")); //"Number", "Phone", "Email", "Gender", "School", "Title", "UnionId", "Avatar", 
        }
    }
}