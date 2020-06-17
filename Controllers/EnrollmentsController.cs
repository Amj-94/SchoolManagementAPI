using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementAPI.Helpers;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMasterService _masterService;
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentsController(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          IMasterService masterService,
                                          IEnrollmentService enrollmentService)
        {
            _unitOfWork = unitOfWork;
            _masterService = masterService;
            _enrollmentService = enrollmentService;
        }

        // GET: api/Enrollment?from=1
        [HttpGet("Read")]
        public IEnumerable<EnrollmentDTO> Read(int from)
        {
            return Mapper.Map<List<EnrollmentDTO>>(_masterService.GetAll<Enrollment>(null, null, null, from, Global.Pages, true).Items);
        }

        // GET: api/Enrollment/5
        [HttpGet("{Code}")]
        public EnrollmentDTO Get(string Code)
        {
            return _enrollmentService.GetEnrollmentDetails(Code);
        }

        //[HttpGet("{EnrollmentStudents}")]
        //public EnrollmentDTO EnrollmentStudents([FromBody] Guid enrollmentGUID)
        //{
        //    //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
        //    //var token = idToken.Result;
        //    var enrollment = _enrollmentService.GetEnrollmentStudents(enrollmentGUID, "");
        //    if (enrollment != null)
        //    {
        //        return enrollment;
        //    }
        //    return null;
        //}

        [HttpGet("NewEnrollment")]
        public EnrollmentDTO NewEnrollment()
        {
            var enrollment = new EnrollmentDTO
            {
                EnrollmentId = _enrollmentService.GetNewEnrollmentId()
            };
            return enrollment;
        }

        // POST: api/Enrollment
        [HttpPost]
        public IActionResult Post([FromBody] EnrollmentDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var enrollment = _enrollmentService.CreateEnrollment(value, "");
                if (enrollment != null)
                {
                    return Ok(enrollment);
                }
                return BadRequest(new { message = "Cannot Create Enrollment" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("AddSubject")]
        public IActionResult AddSubject([FromBody] EnrollmentSubjectDTO subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var enrollmentSubject = _enrollmentService.AddSubject(subject, "");
                if (enrollmentSubject != null)
                {
                    return Ok(enrollmentSubject);
                }
                return BadRequest(new { message = "Cannot Add Subject" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("AddSubjects")]
        public IActionResult AddSubjects([FromBody] EnrollmentSubjectDTO [] subjects, Guid enrollmentGUID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var enrollmentSubjects = _enrollmentService.AddSubjects(enrollmentGUID, subjects, "");
                if (enrollmentSubjects != null)
                {
                    return Ok(enrollmentSubjects);
                }
                return BadRequest(new { message = "Cannot Add Subjects" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("AddSubjectTest")]
        public IActionResult AddSubjectTest([FromBody] EnrollmentSubjectTestDTO subjecttest){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var enrollmentSubjectTest = _enrollmentService.AddSubjectTest(subjecttest, "");
                if (enrollmentSubjectTest != null)
                {
                    return Ok(enrollmentSubjectTest);
                }
                return BadRequest(new { message = "Cannot Add Test" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("AddSubjectTests")]
        public IActionResult AddSubjectTests([FromBody] EnrollmentSubjectTestDTO [] subjecttest, Guid enrollmentSubjectGUID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                //var token = idToken.Result;
                var enrollmentSubjectTests = _enrollmentService.AddSubjectTests(enrollmentSubjectGUID, subjecttest, "");
                if (enrollmentSubjectTests != null)
                {
                    return Ok(enrollmentSubjectTests);
                }
                return BadRequest(new { message = "Cannot Add Tests" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //[HttpPost("AddStudent")]
        //public IActionResult AddStudent([FromBody] Guid student, Guid enrollmentGUID)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
        //        //var token = idToken.Result;
        //        var enrollmentStudent = _enrollmentService.AddStudent(enrollmentGUID, student, "");
        //        if (enrollmentStudent != null)
        //        {
        //            return Ok(enrollmentStudent);
        //        }
        //        return BadRequest(new { message = "Cannot Add Student" });
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }
        //}

        //[HttpPost("AddStudents")]
        //public IActionResult AddStudents([FromBody] List<Guid> students, Guid enrollmentGUID)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        //var idToken = HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
        //        //var token = idToken.Result;
        //        var enrollmentStudents = _enrollmentService.AddStudents(enrollmentGUID, students, "");
        //        if (enrollmentStudents != null)
        //        {
        //            return Ok(enrollmentStudents);
        //        }
        //        return BadRequest(new { message = "Cannot Add Students" });
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }
        //}

        // PUT: api/Enrollments
        [HttpPut("{code}")]
        public IActionResult Update(string code, [FromBody] EnrollmentDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var repo = _unitOfWork.GetRepository<Enrollment>();
                var newval = Mapper.Map<Enrollment>(value);
                newval.EnrollmentId = code;
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
