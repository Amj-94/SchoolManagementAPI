using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.ViewModels
{
    public class YearDTO
    {
        [Required]
        public string YearId { get; set; }
        public Guid YearGUID { get; set; }
        //[Required]
        public string YearCode { get; set; }
        [Required]
        public string YearName1 { get; set; }        
        public string YearName2 { get; set; }
    }
}
