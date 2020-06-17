using System;
using System.ComponentModel.DataAnnotations;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.ViewModels
{
    public class SubjectDTO
    {
        [Required]
        public string SubjectId { get; set; }
        public Guid SubjectGUID { get; set; }
        public string ParentSubjectId { get; set; }
        public string SubjectCode { get; set; }
        [Required]
        public string SubjectName1 { get; set; }
        public string SubjectName2 { get; set; }
        public int General { get; set; }
        public int Glevel { get; set; }
    }
}
