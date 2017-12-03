using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class SigninResult
    {
        public int Id { get; set; } = 10;
        public string Type { get; set; } = "student";
        public string Name { get; set; } = "我";
        public long Exp { get; set; } = DateTime.UtcNow.AddDays(7)
            .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Seconds;
        public string Jwt { get; set; } = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJjaWQiOiJPQTAwMDEiLCJpYXQiOjE0ODI2NTcyODQyMjF9.TeJpy936w610Vrrm+c3+RXouCA9k1AX0Bk8qURkYkdo=";
    }
}
