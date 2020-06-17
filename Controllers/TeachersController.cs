using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SchoolManagementAPI.Helpers;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using SchoolManagementAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeachersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SchoolDBContext _schoolDBContext;
        private readonly IAppUserService _appUserService;
        private readonly IMasterService _masterService;

        public TeachersController(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          SchoolDBContext schoolDBContext,
                                          IAppUserService appUserService,
                                          IMasterService masterService)
        {
            _unitOfWork = unitOfWork;
            _schoolDBContext = schoolDBContext;
            _appUserService = appUserService;
            _masterService = masterService;
        }

        // GET: api/Teacher?from=1
        [HttpGet]
        public IEnumerable<TeacherDTO> Read(int from)
        {
            return Mapper.Map<List<TeacherDTO>>(_masterService.GetAll<Teacher>(null, null, null, from, Global.Pages, true).Items);
        }

        // GET: api/Teacher/5
        //[HttpGet("{Code}", Name = "GetTeachers")]
        //public TeacherDTO Get(string Code)
        //{
        //    return Mapper.Map<TeacherDTO>(_masterService.GetOne<Teacher>(x => x.TeacherCode == Code, null, null, 0, Global.Pages, true));
        //    //return Mapper.Map<TeacherDTO>(_masterService.GetOne<Teacher>(x => x.TeacherCode == Code, null, null, true));
        //}

        // POST: api/Teacher
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> post([FromBody] TeacherDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (value.TeacherCode == null)
                {
                    return BadRequest(new { message = "Teacher Name Id Empty" });
                }
                var user = await _appUserService.Register(value.TeacherCode, null);
                if (user != null)
                {
                    var repo = _unitOfWork.GetRepository<Teacher>();
                    var newvalue = Mapper.Map<Teacher>(value);

                    repo.Add(newvalue);
                    repo.SaveChanges();
                    return Ok();
                }
                return BadRequest(new { message = "Cannot Register User" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
