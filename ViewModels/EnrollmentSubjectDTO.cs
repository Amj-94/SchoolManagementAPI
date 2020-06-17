using System;
namespace SchoolManagementAPI.ViewModels
{
    public class EnrollmentSubjectDTO
    {
        public Guid SubjectGUID { get; set; }
        public Guid EnrollmentGUID { get; set; }
        public Guid EnrollmentSubjectGUID { get; set; }
        public float MinMark { get; set; }
        public float MaxMark { get; set; }
        public bool Included { get; set; }
    }
}
