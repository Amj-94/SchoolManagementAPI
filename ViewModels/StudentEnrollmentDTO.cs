using System;
namespace SchoolManagementAPI.ViewModels
{
    public class StudentEnrollmentDTO
    {
        public Guid StudentGUID { get; set; }
        public Guid EnrollmentGUID { get; set; }
        public Guid StudentEnrollmentGUID { get; set; }
    }
}
