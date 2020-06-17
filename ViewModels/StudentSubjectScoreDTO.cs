using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.ViewModels
{
    public class StudentSubjectScoreDTO
    {
        [Required]
        public Guid StudentGUID { get; set; }
        [Required]
        public Guid EnrollmentGUID { get; set; }
        public Guid StudentEnrollmentGUID { get; set; }
        [Required]
        public Guid EnrollmentSubjectTestGUID { get; set; }
        public float Score { get; set; }
    }
}
