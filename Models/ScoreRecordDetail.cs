using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementAPI.Models
{
    public class ScoreRecordDetail : Base
    {
        public ScoreRecordDetail()
        {
            ScoreRecordDetailGuid = Guid.NewGuid();
        }
        public Guid EnrollmentStudentGUID { get; set; }
        public Guid EnrollmentSubjectGUID { get; set; }
        public Guid ScoreRecordDetailGuid { get; set; }
        public float Mark { get; set; }
        public string Remark { get; set; }
        public DateTime ScoreDate { get; set; }
        //[ForeignKey("EnrollmentStudentGUID")]
        public virtual EnrollmentStudent EnrollmentStudent { get; set; }
        //[ForeignKey("EnrollmentSubjectGUID")]
        public virtual EnrollmentSubject EnrollmentSubject { get; set; }
    }
}
