using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.ViewModels
{
    public class GradeDTO
    {
        public string GradeId { get; set; }
        public Guid GradeGUID { get; set; }
        //[Required]
        public string GradeCode { get; set; }
        [Required]
        public string GradeName1 { get; set; }
        public string GradeName2 { get; set; }
        public string GradeSymbol { get; set; }
    }
}
