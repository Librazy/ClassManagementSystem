using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassManagementSystem.Controllers;

namespace ClassManagementSystem.Models
{
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

    public class Group
    {
        public Group()
        {
            Id = 0;
        }

        public long Id { get; }

        public User Leader { get; set; }

        public List<User> Members { get; set; }

        public List<Topic> Topics { get; set; }

        public string Report { get; set; }

        public GroupGrade Grade { get; set; }
    }
}
