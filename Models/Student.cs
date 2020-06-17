using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementAPI.Models
{
    public class Student : Base
    {
        public Student()
        {
            StudentGUID = Guid.NewGuid();
        }
        [Key]
        public string StudentId { get; set; }
        public Guid StudentGUID { get; set; }
        [Required]
        public string StudentCode { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string StudentName { get; set; }
        public string StudentMobile { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string FatherName { get; set; }
        public string FatherMobile { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string MotherName { get; set; }
        public string MotherMobile { get; set; }

        public string BirthCity { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy, hh:mm:tt}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
        public string Address { get; set; }

        public List<StudentAttendance> StudentAttendances { get; set; }
        public List<StudentEnrollment> StudentEnrollments { get; set; }
        public List<StudentSubjectScore> StudentSubjectScores { get; set; }

        //public List<EnrollmentStudent> EnrollmentStudents { get; set; }

        [ForeignKey("UserId")]
        public AppUser User_1 { get; set; }

    }

    public enum Gender
    {
        Male = 0,
        Female = 1
    }
}
