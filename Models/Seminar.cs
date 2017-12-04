using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class Seminar
    {
        public Seminar(long id)
        {
            Id = id;
        }

        public long Id { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string GroupingMethod { get; set; }

        public Proportions Proportions { get; set; }
    }
}
