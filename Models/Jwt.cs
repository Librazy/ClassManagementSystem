using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class Jwt
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public long Exp { get; set; }
    }
}
