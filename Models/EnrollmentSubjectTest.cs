using System;
using System.Collections.Generic;

namespace SchoolManagementAPI.Models
{
    public class EnrollmentSubjectTest : Base
    {
        public EnrollmentSubjectTest()
        {
            EnrollmentSubjectTestGUID = Guid.NewGuid(); 
        }
        public string TestID { get; set; }
        public Guid EnrollmentSubjectGUID { get; set; }
        public Guid EnrollmentSubjectTestGUID { get; set; }
        public string TestName { get; set; }
        public TestType Type { get; set; }
        public float MinMark { get; set; }
        public float MaxMark { get; set; }
        public bool Included { get; set; }
        public virtual EnrollmentSubject EnrollmentSubject { get; set; }
        public List<StudentSubjectScore> StudentSubjectScores { get; set; }

        public enum TestType
        {
            General,
            OralTest,
            WrtingTest,
            Quiz,
            Homework
        }

    }
}
