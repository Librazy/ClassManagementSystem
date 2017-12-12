using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class School
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "BIGINT(20)")]
        public long Id { get; protected set; }

        [Column("school_name", TypeName = "VARCHAR(20)")]
        public string Name { get; set; }

        [Column("province", TypeName = "VARCHAR(10)")]
        public string Province { get; set; }

        [Column("city", TypeName = "VARCHAR(10)")]
        public string City { get; set; }
    }
}
