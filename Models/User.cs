using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class User
    {
        public User(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
