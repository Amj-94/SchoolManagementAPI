using System;
using System.Threading.Tasks;
using SchoolManagementAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.Services.Interfaces;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppUsersController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly SchoolDBContext _schoolDBContext;
        private readonly IAppUserService _appUserService;
        //private readonly UserManager<AppUser> _userManager;
        //private readonly SignInManager<AppUser> _signInManager;
        //private readonly AppSettings _appSettings;

        public AppUsersController(IAppUserService appUserService)
                                //IOptions<AppSettings> appSettings,
                                //IUnitOfWork<SchoolDBContext> unitOfWork,
                                //SchoolDBContext schoolDBContext,
                                //IAppUserService appUserService,
                                //UserManager<AppUser> userManager,
                                //SignInManager<AppUser> signInManager)
        {
            //_appSettings = appSettings.Value;
            //_unitOfWork = unitOfWork;
            //_schoolDBContext = schoolDBContext;
            _appUserService = appUserService;
            //_userManager = userManager;
            //_signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AppUserRegisterDTO value)
        {
            try
            {
                var user = await _appUserService.Register(value.UserName , value.Password);
                if (user == null)
                    return BadRequest(new { message = "Unknow Reason" });
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] AppUserLogInDTO value)
        {
            try
            {
                var user = await _appUserService.LogIn(value.UserName, value.Password);
                if (user == null)
                    return BadRequest(new { message = "Unknow Reason" });
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
