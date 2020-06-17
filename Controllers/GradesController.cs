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
using SchoolManagementAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class GradesController : ControllerBase
    {        
        private readonly SchoolDBContext _schoolDBContext;
        private readonly IMasterService _masterService;        
        private readonly IGradeService _gradeService;

        public GradesController(SchoolDBContext schoolDBContext,
                                          IMasterService masterService,
                                          IGradeService gradeService)
        {
            _schoolDBContext = schoolDBContext;
            _masterService = masterService;
            _gradeService = gradeService;
        }
        // GET: api/Grade?from=1
        [HttpGet("Read")]
        public IEnumerable<GradeDTO> Read(int from)
        {
            return Mapper.Map<List<GradeDTO>>(_masterService.GetAll<Grade>(null, null, null, from, Global.Pages, true).Items);
        }

        // GET: api/Grade/5
        [HttpGet("{Code}")]
        public GradeDTO Get(string Code)
        {
            return Mapper.Map<GradeDTO>(_masterService.GetOne<Grade>(x => x.GradeId == Code));
        }

        [HttpGet("NewGrade")]
        public GradeDTO CreateGrade()
        {
            var grade = new GradeDTO
            {
                GradeId = _gradeService.GetNewGradeId()
            };
            return grade;
        }

        // POST: api/Grade
        [HttpPost]
        public IActionResult post([FromBody] GradeDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var grade = _gradeService.CreateGrade(value, "");
                if (grade != null)
                {
                    return Ok(grade);
                }
                return BadRequest(new { message = "Cannot Create Grade" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
