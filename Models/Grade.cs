using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.Models
{
    public class Grade : Base
    {
        public Grade()
        {
            GradeGUID = Guid.NewGuid();
        }
        [Key]
        public string GradeId { get; set; }
        public Guid GradeGUID { get; set; }
        [Required]
        public string GradeCode { get; set; }
        [Required]
        public string GradeName1 { get; set; }
        public string GradeName2 { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        //[Required]
        //public string GradeSymbol { get; set; }
        //List<Section> GradeSections { get; set; }
    }
}