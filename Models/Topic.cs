using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class Topic
    {
        public Topic()
        {
            Id = 0;
        }

        public long Id { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int GroupLimit { get; set; }

        public List<Group> Groups { get; set; } = new List<Group>();

        public int GroupLeft => GroupLimit - Groups.Count;

    }
}
