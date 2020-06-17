using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementAPI.Models
{
    public class EnrollmentStudent : Base
    {
        public EnrollmentStudent()
        {
            EnrollmentStudentGUID = Guid.NewGuid();
        }

        public Guid StudentGUID { get; set; }
        public Guid EnrollmentGUID { get; set; }
        public Guid EnrollmentStudentGUID { get; set; }
        //public List<ScoreRecordDetail> ScoreRecordDetails { get; set; }
        //[ForeignKey("StudentGUID")]
        public virtual Student Student { get; set; }
        //[ForeignKey("EnrollmentGUID ")]
        public virtual Enrollment Enrollment { get; set; }
        
    }
}
