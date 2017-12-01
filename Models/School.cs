using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class School
    {
        public School()
        {
            Id = 0;
        }

        public long Id { get; }

        public string Name { get; set; }

        public string Province { get; set; }

        public string City { get; set; }
    }
}
