using System;
using System.Collections.Generic;

namespace SchoolManagementAPI.Models
{
    public class StudentEnrollment : Base
    {
        public StudentEnrollment()
        {
            StudentEnrollmentGUID = Guid.NewGuid();
        }
        public Guid StudentGUID { get; set; }
        public Guid EnrollmentGUID { get; set; }
        public Guid StudentEnrollmentGUID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Enrollment Enrollment { get; set; }
        public List<StudentSubjectScore> StudentSubjectScores { get; set; }
    }
}
