using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.Models
{
    public class Year : Base
    {
        public Year()
        {
            YearGUID = Guid.NewGuid();
        }
        [Key]
        public string YearId { get; set; }
        public Guid YearGUID { get; set; }
        [Required]
        public string YearCode { get; set; }
        [Required]
        public string YearName1 { get; set; }
        public string YearName2 { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}
