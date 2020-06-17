using System;
namespace SchoolManagementAPI.Models
{
    public class StudentSubjectScore : Base
    {
        public StudentSubjectScore()
        {
            //StudentSubjectScoreGUID = Guid.NewGuid();
        }
        public Guid StudentGUID { get; set; }
        public Guid StudentEnrollmentGUID { get; set; }
        public Guid EnrollmentSubjectTestGUID { get; set; }
        public float Score { get; set; }
        //public Guid StudentSubjectScoreGUID { get; set; }

        public virtual Student Student { get; set; }
        public virtual StudentEnrollment StudentEnrollment { get; set; }
        public virtual EnrollmentSubjectTest EnrollmentSubjectTest { get; set; }
    }
}
