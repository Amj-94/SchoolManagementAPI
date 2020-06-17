using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using SchoolManagementAPI.Helpers;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using SchoolManagementAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class SemestersController : ControllerBase
    {        
        private readonly SchoolDBContext _schoolDBContext;
        private readonly IMasterService _masterService;
        private readonly ISemesterService _semesterService;

        public SemestersController(SchoolDBContext schoolDBContext,
                                          IMasterService masterService,
                                          ISemesterService semesterService)
        {
            _schoolDBContext = schoolDBContext;
            _masterService = masterService;
            _semesterService = semesterService;
        }
        // GET: api/Semester?from=1
        [HttpGet("Read")]
        public IEnumerable<SemesterDTO> Read(int from)
        {
            return Mapper.Map<List<SemesterDTO>>(_masterService.GetAll<Semester>(null, null, null, from, Global.Pages, true).Items);
        }

        // GET: api/Semester/5
        [HttpGet("{Code}")]
        public SemesterDTO Get(string Code)
        {
            return Mapper.Map<SemesterDTO>(_masterService.GetOne<Semester>(x => x.SemesterId == Code));
        }

        [HttpGet("NewSemester")]
        public SemesterDTO CreateSemester()
        {
            var Semester = new SemesterDTO
            {
                SemesterId = _semesterService.GetNewSemesterId()
            };
            return Semester;
        }

        // POST: api/Semester
        [HttpPost]
        public IActionResult post([FromBody] SemesterDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var semester = _semesterService.CreateSemester(value, "");
                if (semester != null)
                {
                    return Ok(semester);
                }
                return BadRequest(new { message = "Cannot Create Semester" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}