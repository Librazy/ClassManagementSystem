using System.Collections.Generic;
using System.Linq;

namespace ClassManagementSystem.Models
{
    public class Course
    {
        public long Id { get; protected set; }

        public string Name { get; set; }

        public int NumClass => Classes.Count;

        public User Teacher { get; set; } = new User {Type = User.UserType.Teacher};

        public string TeacherName => Teacher.Name;

        public string TeacherEmail => Teacher.Email;

        public List<Class> Classes { get; set; } = new List<Class>();

        public List<Seminar> Seminars { get; set; } = new List<Seminar>();

        public int NumStudent => Classes.Aggregate(0, (total, current) => total + current.NumStudent);

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Description { get; set; }

        public Proportions Proportions { get; set; }
    }
}