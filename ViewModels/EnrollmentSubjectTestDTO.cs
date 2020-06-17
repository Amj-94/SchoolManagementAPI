using System;
using System.ComponentModel.DataAnnotations;
using static SchoolManagementAPI.Models.EnrollmentSubjectTest;

namespace SchoolManagementAPI.ViewModels
{
    public class EnrollmentSubjectTestDTO
    {
        [Required]
        public string TestID { get; set; }
        [Required]
        public Guid EnrollmentSubjectGUID { get; set; }
        public string TestName { get; set; }
        public TestType Type { get; set; }
        public float MinMark { get; set; }
        public float MaxMark { get; set; }
        public bool Included { get; set; }
    }
}
