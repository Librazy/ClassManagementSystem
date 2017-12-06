using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class Topic
    {
        public Topic(long id)
        {
            Id = id;
        }

        public long Id { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Serial { get; set; }

        public int GroupLimit { get; set; }

        public int GroupMemberLimit { get; set; }

        public List<Group> Groups { get; set; } = new List<Group>();

        public int GroupLeft => GroupLimit - Groups.Count;

    }
}
