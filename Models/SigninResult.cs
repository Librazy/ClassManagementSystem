using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class SigninResult
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public long Exp { get; set; }
        public string Jwt { get; set; }
    }
}
