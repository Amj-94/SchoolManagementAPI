using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementAPI.Models
{
    public class Subject : Base
    {
        public Subject()
        {
            SubjectGUID = Guid.NewGuid();
        }
        [Key]
        public string SubjectId { get; set; }
        public Guid SubjectGUID { get; set; }
        [Required]
        public string SubjectCode { get; set; }
        public string ParentSubjectId { get; set; }
        public string SubjectName1 { get; set; }
        public string SubjectName2 { get; set; }
        public int General { get; set; }
        public int GLevel { get; set; }
        [ForeignKey("ParentSubjectId")]
        public virtual Subject Subject1 { get; set; }
        public List<EnrollmentSubject> EnrollmentSubjects { get; set; }
    }    
}
