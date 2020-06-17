using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.ViewModels
{
    public class EnrollmentDTO
    {
        [Required]
        public string EnrollmentId { get; set; }
        public Guid EnrollmentGUID { get; set; }
        public string EnrollmentCode { get; set; }
        [Required]
        public Guid YearGUID { get; set; }
        [Required]
        public Guid SemesterGUID { get; set; }
        [Required]
        public Guid GradeGUID { get; set; }
        [Required]
        public Guid SectionGUID { get; set; }        
        public List<Student> EnrollmentStudents { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
