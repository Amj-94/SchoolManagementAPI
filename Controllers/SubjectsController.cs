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
using System.Threading.Tasks;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class SubjectsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SchoolDBContext _schoolDBContext;
        private readonly IMasterService _masterService;
        private readonly ISubjectService _subjectService;

        public SubjectsController(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          SchoolDBContext schoolDBContext,
                                          IMasterService masterService,
                                          ISubjectService subjectService)
        {
            _unitOfWork = unitOfWork;
            _schoolDBContext = schoolDBContext;
            _masterService = masterService;
            _subjectService = subjectService;
        }
        // GET: api/Subject?from=1
        [HttpGet("Read")]
        public IEnumerable<SubjectDTO> Read(int from)
        {
            return Mapper.Map<List<SubjectDTO>>(_masterService.GetAll<Subject>(null, null, null, from, Global.Pages, true).Items);
        }

        //GET: api/Subject/5
        [HttpGet("{Code}")]
        public SubjectDTO Get(string Code)
        {
            return Mapper.Map<SubjectDTO>(_masterService.GetOne<Subject>(x => x.SubjectId == Code));
        }

        [HttpGet("NewSubject")]
        public SubjectDTO CreateSubject()
        {
            var subject = new SubjectDTO
            {
                SubjectId = _subjectService.GetNewSubjectId()
            };
            return subject;
        }

        // POST: api/Subject
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SubjectDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var subject = await _subjectService.CreateSubject(value, "");
                if (subject != null)
                {
                    return Ok(subject);
                }
                return BadRequest(new { message = "Cannot Create Subject" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
