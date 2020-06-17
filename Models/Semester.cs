using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.Models
{
    public class Semester : Base
    {
        public Semester()
        {
            SemesterGUID = Guid.NewGuid();
        }
        [Key]
        public string SemesterId { get; set; }
        public Guid SemesterGUID { get; set; }
        [Required]
        public string SemesterCode { get; set; }
        [Required]
        public string SemesterName1 { get; set; }
        public string SemesterName2 { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}
