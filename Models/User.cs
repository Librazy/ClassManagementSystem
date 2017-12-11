using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ClassManagementSystem.Models
{
    public class User
    {
        public enum GenderType
        {
            [EnumMember(Value = "male")] Male,
            [EnumMember(Value = "female")] Female
        }

        public enum UserType
        {
            [EnumMember(Value = "student")] Student,
            [EnumMember(Value = "teacher")] Teacher,
            [EnumMember(Value = "unbinded")] Unbinded
        }

        public User(long id) => Id = id;

        public User()
        {
        }

        [Key]
        [Column("id", TypeName = "BIGINT(20)")]
        public long Id { get; protected set; }

        [Column("is_male", TypeName = "TINYINT(1)")]
        public UserType Type { get; set; }

        [Column("number", TypeName = "VARCHAR(20)")]
        public string Number { get; set; }

        [Column("user_name", TypeName = "VARCHAR(10)")]
        public string Name { get; set; }

        [Column("phone_number", TypeName = "CHAR(11)")]
        public string Phone { get; set; }

        [Column("email", TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Column("is_male", TypeName = "TINYINT(1)")]
        public GenderType Gender { get; set; }

        [ForeignKey("school_id")]
        public School School { get; set; }

        [Column("title", TypeName = "VARCHAR(11)")]
        public string Title { get; set; }

        [JsonIgnore]
        [Column("user_password", TypeName = "VARCHAR(16)")]
        public string Password { get; set; }

        [Column("wechat_id", TypeName = "VARCHAR(50)")]
        public string UnionId { get; set; }

        [Column("icon", TypeName = "VARCHAR(50)")]
        public string Avatar { get; set; }
    }
}