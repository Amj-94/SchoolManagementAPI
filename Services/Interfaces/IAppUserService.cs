using System;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.ModelViews;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface IAppUserService
    {
        //Task<object> GenerateJwtToken(AppUser appUser);

        //Task<object> Register(string userName, string password);

        Task<AppUsersDTO> Register(string userName, string password);

        Task<AppUsersDTO> LogIn(string userName, string password);

        public string GetUserId(string Token);

        public Task DeleteUser(string Id);

    }
}
