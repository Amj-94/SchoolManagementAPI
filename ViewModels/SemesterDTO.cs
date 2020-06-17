using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.ViewModels
{
    public class SemesterDTO
    {
        public string SemesterId { get; set; }
        public Guid SemesterGUID { get; set; }
        //[Required]
        public string SemesterCode { get; set; }
        [Required]
        public string SemesterName1 { get; set; }
        public string SemesterName2 { get; set; }
    }
}
