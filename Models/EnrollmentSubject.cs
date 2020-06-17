using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementAPI.Models
{
    public class EnrollmentSubject : Base
    {
        public EnrollmentSubject()
        {
            EnrollmentSubjectGUID = Guid.NewGuid();
        }
        public Guid SubjectGUID { get; set; }
        public Guid EnrollmentGUID { get; set; }
        public Guid EnrollmentSubjectGUID { get; set; }
        public float MinMark { get; set; }
        public float MaxMark { get; set; }
        public bool Included { get; set; }        
        public virtual Enrollment Enrollment { get; set; }
        public virtual Subject Subject { get; set; }

        public List<EnrollmentSubjectTest> EnrollmentSubjectTests { get; set; }
    }
}
