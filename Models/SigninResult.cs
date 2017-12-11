using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class SigninResult
    {
        public long Id { get; set; }
        public User.UserType Type { get; set; }
        public string Name { get; set; }
        public long Exp { get; set; }
        public string Jwt { get; set; }
    }
}
