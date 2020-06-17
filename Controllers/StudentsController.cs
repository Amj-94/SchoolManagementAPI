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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SchoolManagementAPI.Services;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SchoolDBContext _schoolDBContext;
        private readonly IMasterService _masterService;
        private readonly IStudentService _studentService;

        public StudentsController(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          SchoolDBContext schoolDBContext,
                                          IMasterService masterService,
                                          IStudentService studentService)
        {
            _unitOfWork = unitOfWork;
            _schoolDBContext = schoolDBContext;
            _masterService = masterService;
            _studentService = studentService;
        }
        [HttpGet("{Str1}")]
        public string riverseString(string str)
        {
            char[] chararray = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                chararray[i] = str[j];
                chararray[j] = str[i];
            }
            string reversedString = new string(chararray);
            return reversedString;
        }

        // GET: api/Student?from=1
        [HttpGet("Read")]
        public IEnumerable<StudentDTO> Read(int from)
        {
            return Mapper.Map<List<StudentDTO>>(_masterService.GetAll<Student>(null, null, null, from, Global.Pages, true).Items);
        }

        //  api/Student/5
        [HttpGet("{Code}")]
        public StudentDTO Get(string Code)
        {            
            return Mapper.Map<StudentDTO>(_masterService.GetOne<Student>(x => x.StudentId == Code));
        }

        [HttpGet("NewStudent")]
        public StudentDTO NewStudent()
        {
            var student = new StudentDTO
            {
                StudentId = _studentService.GetNewStudentId()
            };
            return student;
        }

        // POST: api/Student
        [HttpPost]
        public async Task<IActionResult> RegisterStudent([FromBody] StudentDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var student = await _studentService.CreateStudent(value, "");
                if (student != null)
                {
                    return Ok(student);
                }
                return BadRequest(new { message = "Cannot Create Student" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("AddStudentEnrollment")]
        public IActionResult AddStudentEnrollment([FromBody] StudentEnrollmentDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var studentEnrollment = _studentService.AddStudentEnrollment(value, "");
                if (studentEnrollment != null)
                {
                    return Ok(studentEnrollment);
                }
                return BadRequest(new { message = "Cannot Add Student Enrollment" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
                
        [HttpPost("AddStudentSubjectTest")]
        public IActionResult AddStudentSubjectTest([FromBody] StudentSubjectScoreDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var studentSubjectScore = _studentService.AddStudentSubjectScore(value, "");
                if (studentSubjectScore != null)
                {
                    return Ok(studentSubjectScore);
                }
                return BadRequest(new { message = "Cannot Add Student Subject Score" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT: api/Student
        [HttpPut("{code}")]
        public IActionResult Update(string code, [FromBody] StudentDTO value)
        {
            try
            {
                var repo = _unitOfWork.GetRepository<Student>();
                var newval = Mapper.Map<Student>(value);
                newval.StudentId = code;
                repo.Update(newval);
                repo.SaveChanges();
                return Ok(newval);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
