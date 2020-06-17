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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class SectionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SchoolDBContext _schoolDBContext;
        private readonly IMasterService _masterService;
        private readonly ISectionService _sectionService;

        public SectionsController(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          SchoolDBContext schoolDBContext,
                                          IMasterService masterService,
                                          ISectionService sectionService)
        {
            _unitOfWork = unitOfWork;
            _schoolDBContext = schoolDBContext;
            _masterService = masterService;
            _sectionService = sectionService;
        }
        // GET: api/Section?from=1
        [HttpGet("Read")]
        public IEnumerable<SectionDTO> Read(int from)
        {
            return Mapper.Map<List<SectionDTO>>(_masterService.GetAll<Section>(null, null, null, from, Global.Pages, true).Items);
        }

        // GET: api/Section/5
        [HttpGet("{Code}")]
        public SectionDTO Get(string Code)
        {
            return Mapper.Map<SectionDTO>(_masterService.GetOne<Section>(x => x.SectionId == Code));
        }

        [HttpGet("NewSection")]
        public SectionDTO CreateSection()
        {
            var section = new SectionDTO
            {
                SectionId = _sectionService.GetNewSectionId()
            };
            return section;
        }

        // POST: api/Section
        [HttpPost]
        public IActionResult CreateSection([FromBody] SectionDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var section = _sectionService.CreateSection(value, "");
                if (section != null)
                {
                    return Ok(section);
                }
                return BadRequest(new { message = "Cannot Create Section" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}