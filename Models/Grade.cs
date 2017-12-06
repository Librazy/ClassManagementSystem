using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassManagementSystem.Models
{
    public class Grade
    {
        public Grade(long id)
        {
            Id = id;
        }

        public long Id { get; set; }

        public string SeminarName { get; set; }

        public string GroupName { get; set; }

        public string LeaderName { get; set; }

        public int PresentationGrade { get; set; }

        public int ReportGrade { get; set; }

        public int FinalGrade { get; set; }
    }
}
