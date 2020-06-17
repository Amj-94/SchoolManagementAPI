using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementAPI.Models
{
    public class AppClaim
    {
        public AppClaim()
        {
            ClaimGUID = Guid.NewGuid();
        }
        [Key]
        public string ClaimCode { get; set; }
        public string ClaimName1 { get; set; }
        public string ClaimName2 { get; set; }
        public Guid ClaimGUID { get; set; }
    }
}
