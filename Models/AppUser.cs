using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SchoolManagementAPI.Models
{
    public class AppUser : IdentityUser
    {
        public string Token { get; set; }
    }
}
