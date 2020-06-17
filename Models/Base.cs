using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI
{
    public class Base
    {
        public Base()
        {
            CreationDate = DateTime.Now;
            Deleted = false;
        }
        public bool? Deleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string EditedBy { get; set; }
        public DateTime LastTimeEdited { get; set; }
        //[ForeignKey("CreatedBy")]
        //public virtual AppUser User_3 { get; set; }
        //[ForeignKey("EditedBy")]
        //public virtual AppUser User_4 { get; set; }
    }
}