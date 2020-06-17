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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class YearsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SchoolDBContext _schoolDBContext;
        private readonly IMasterService _masterService;
        private readonly IYearService _yearService;

        public YearsController(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          SchoolDBContext schoolDBContext,
                                          IMasterService masterService,
                                          IYearService yearService)
        {
            _unitOfWork = unitOfWork;
            _schoolDBContext = schoolDBContext;
            _masterService = masterService;
            _yearService = yearService;
        }

        // GET: api/Year?from=1
        [HttpGet("Read")]
        public IEnumerable<YearDTO> Read(int from)
        {
            return Mapper.Map<List<YearDTO>>
                (_masterService.GetAll<Year>
                (null, null, null, from, Global.Pages, true).Items);
        }

        //GET: api/Year/5
        [HttpGet("{Code}")]
        public YearDTO Get(string Code)
        {
            return Mapper.Map<YearDTO>
                (_masterService.GetOne<Year>(x => x.YearId == Code));
        }

        [HttpGet("NewYear")]
        public YearDTO CreateYear()
        {
            var year = new YearDTO
            {
                YearId = _yearService.GetNewYearId()
            };
            return year;
        }

        // POST: api/Year
        [HttpPost]       
        public IActionResult CreateYear([FromBody] YearDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                var token = idToken.Result;
                var year = _yearService.CreateYear(value, "");
                if (year != null)
                {
                    return Ok(year);
                }
                return BadRequest(new { message = "Cannot Create Year" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}