using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementAPI.Models
{
    public class Section : Base
    {
        public Section()
        {
            SectionGUID = Guid.NewGuid();
        }
        [Key]
        public string SectionId { get; set; }
        public Guid SectionGUID { get; set; }
        [Required]
        public string SectionCode { get; set; }
        [Required]
        public string SectionName1 { get; set; }
        public string SectionName2 { get; set; }
        [Required]
        public string SectionSymbol { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}
