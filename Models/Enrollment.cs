using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementAPI.Models
{
    public class Enrollment : Base
    {
        public Enrollment()
        {
            EnrollmentGUID = Guid.NewGuid();
        }
        public string EnrollmentId { get; set; }
        public Guid EnrollmentGUID { get; set; }
        public string EnrollmentCode { get; set; }
        public Guid YearGUID { get; set; }
        public Guid SemesterGUID { get; set; }
        public Guid GradeGUID { get; set; }
        public Guid SectionGUID { get; set; }
        //[ForeignKey("YearId")]
        public virtual Year Year { get; set; }
        //[ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
        //[ForeignKey("GradeId")]
        public virtual Grade Grade { get; set; }
        //[ForeignKey("SectionId")]
        public virtual Section Section { get; set; }
        public List<EnrollmentAttendance> EnrollmentAttendances { get; set; }
        public List<StudentEnrollment> StudentEnrollments { get; set; }
        public List<Student> EnrollmentStudents { get; set; }
        public List<Subject> Subjects { get; set; }
        //public List<EnrollmentStudent> EnrollmentStudents { get; set; }
        public List<EnrollmentSubject> EnrollmentSubjects { get; set; }
    }
}
