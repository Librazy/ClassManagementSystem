using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class Course
    {
        public Course(long id)
        {
            Id = id;
        }

        public long Id { get; }

        public int NumClass => Classes.Count;

        public List<Class> Classes { get; set; }

        public int NumStudent => Classes.Aggregate(0, (total, current) => total + current.NumStudent);

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Description { get; set; }

        public Proportions Proportions { get; set; }
    }
}
