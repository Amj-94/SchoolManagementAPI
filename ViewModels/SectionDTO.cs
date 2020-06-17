using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.ViewModels
{
    public class SectionDTO
    {
        public string SectionId { get; set; }
        public Guid SectionGUID { get; set; }
        //[Required]
        public string SectionCode { get; set; }
        [Required]
        public string SectionName1 { get; set; }
        public string SectionName2 { get; set; }
        public string SectionSymbol { get; set; }
    }
}
