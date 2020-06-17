using System;
using System.ComponentModel.DataAnnotations;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;

namespace SchoolManagementAPI.ViewModels
{
    public class StudentDTO
    {
        public string StudentId { get; set; }
        public Guid StudentGUID { get; set; }
        //[Required]
        public string StudentCode { get; set; }
        //public string UserId { get; set; }
        [Required]
        public string StudentName { get; set; }
        public string StudentMobile { get; set; }
        public string FatherName { get; set; }
        public string FatherMobile { get; set; }
        public string MotherName { get; set; }
        public string MotherMobile { get; set; }
        public string BirthCity { get; set; }
        //public string BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
    }
}
