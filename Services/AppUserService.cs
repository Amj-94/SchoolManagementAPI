using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SchoolManagementAPI.Helpers;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.ModelViews;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace SchoolManagementAPI.Services
{      
    public class AppUserService : IAppUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserService(IOptions<AppSettings> appSettings,
                              IUnitOfWork<SchoolDBContext> unitOfWork,
                              UserManager<AppUser> usermanager,
                              SignInManager<AppUser> signInManager)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _userManager = usermanager;
            _signInManager = signInManager;
        }

        private object GenerateJwtToken(AppUser appUser)
        {
            var rep = _unitOfWork.GetRepository<AppUser>();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, appUser.UserName)
                    , new Claim(ClaimTypes.NameIdentifier,appUser.Id.ToString())
                }),
                //Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            appUser.Token = tokenHandler.WriteToken(token);
            rep.Update(appUser);
            rep.SaveChanges();

            return new JwtSecurityTokenHandler().WriteToken(token);
        }        

        public async Task<AppUsersDTO> Register(string userName, string password)
        {
            var user = new AppUser
            {
                UserName = userName
            };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    //var token = GenerateJwtToken(user);
                    user.Token = (string)GenerateJwtToken(user);
                    var result1 = await _userManager.UpdateAsync(user);
                    if (result1.Succeeded)
                    {
                        return Mapper.Map<AppUsersDTO>(user);
                    }
                    throw new Exception("Cannot Update Token");
                }            
            throw new Exception("Cannot Create User");
        }

        public async Task<AppUsersDTO> LogIn(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    user.Token = (string)GenerateJwtToken(user);
                }
                return Mapper.Map<AppUsersDTO>(user);
            }
            throw new Exception("Cannot LogIn User");
        }

        public string GetUserId(string Token)
        {
            var user = _unitOfWork.GetReadOnlyRepository<AppUser>().Single(x => x.Token == Token);
            if (user != null)
            {
                return user.Id;
            }
            return "";
        }

        public async Task DeleteUser(string Id)
        {
            if (Id != null)
            {
                var user = await _userManager.FindByIdAsync(Id);
                await _userManager.DeleteAsync(user);
            }
        }
    }
}
