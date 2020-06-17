using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementAPI.Models
{
    public class Teacher : Base
    {
        public Teacher()
        {
            TeacherGUID = Guid.NewGuid();
        }
        [Key]
        public string TeacherId { get; set; }
        public Guid TeacherGUID { get; set; }
        [Required]
        public string TeacherCode { get; set; }
        [Required]
        public string UserId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string TeacherName { get; set; }
        public string TeacherMobile { get; set; }       

        [ForeignKey("UserId")]
        public AppUser User_1 { get; set; }
    }
}
