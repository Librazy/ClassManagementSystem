using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClassManagementSystem.Models
{
    public class User
    {
        public User(long id)
        {
            Id = id;
        }

        public long Id { get; }

        public string Type { get; set; }

        public string Number { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public School School { get; set; }

        public string Title { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string UnionId { get; set; }

        public string Avatar { get; set; }
    }
}
