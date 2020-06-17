using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppUserService _appUserService;
        private readonly IMasterService _masterService;
        public StudentService(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          IAppUserService appUserService,
                                          IMasterService masterService)
        {
            _unitOfWork = unitOfWork;
            _appUserService = appUserService;
            _masterService = masterService;
        }

        public StudentSubjectScoreDTO AddStudentSubjectScore(StudentSubjectScoreDTO value, string token)
        {
            var studentEnrollmentExist = _masterService.GetOne<StudentEnrollment>(x => x.EnrollmentGUID == value.EnrollmentGUID && x.StudentGUID == value.StudentGUID);

            if (studentEnrollmentExist != null)
            {                
                var repo = _unitOfWork.GetRepository<StudentSubjectScore>();
                var newvalue = Mapper.Map<StudentSubjectScore>(value);
                newvalue.StudentEnrollmentGUID = studentEnrollmentExist.StudentEnrollmentGUID;
                //newvalue.CreatedBy = _appUserService.GetUserId(token);
                repo.Add(newvalue);
                repo.SaveChanges();
                return Mapper.Map<StudentSubjectScoreDTO>(newvalue);

            }
            throw new Exception("Student is not in this enrollment");
        }

        public StudentEnrollmentDTO AddStudentEnrollment(StudentEnrollmentDTO value, string token)
        {
            var studentExist = _unitOfWork.GetReadOnlyRepository<StudentEnrollment>().Single(x => x.StudentGUID == value.StudentGUID && x.EnrollmentGUID == value.EnrollmentGUID);
            if (studentExist == null)
            {
                var newvalue = Mapper.Map<StudentEnrollment>(value);
                newvalue.StudentEnrollmentGUID = Guid.NewGuid();
                var repo = _unitOfWork.GetRepository<StudentEnrollment>();
                repo.Add(newvalue);
                repo.SaveChanges();
                return Mapper.Map<StudentEnrollmentDTO>(newvalue);
            }
            throw new Exception("Student Enrollment Exist");
        }

        public async Task<StudentDTO> CreateStudent(StudentDTO value, string token)
        {
            var UserId = "";
            try
            {
                var user = await _appUserService.Register(value.StudentId, value.StudentId);
                if (user != null)
                {
                    UserId = user.Id;
                    var repo = _unitOfWork.GetRepository<Student>();
                    var newvalue = Mapper.Map<Student>(value);
                    newvalue.UserId = user.Id;
                    newvalue.StudentGUID = Guid.NewGuid();
                    if (newvalue.StudentCode == null) newvalue.StudentCode = value.StudentId;
                    //newvalue.CreatedBy = _appUserService.GetUserId(token);
                    newvalue.CreationDate = DateTime.Now;
                    newvalue.BirthDate = DateTime.Now;
                    newvalue.LastTimeEdited = DateTime.Now;
                    repo.Add(newvalue);
                    repo.SaveChanges();
                    return Mapper.Map<StudentDTO>(newvalue);
                }
                throw new Exception("Cannot create user");
            }
            catch (Exception ex)
            {
                await _appUserService.DeleteUser(UserId);
                throw new Exception(ex.Message);
            }
        }

        public string GetNewStudentId()
        {
            var record = _unitOfWork.GetReadOnlyRepository<Student>().Single(null, null, x => x.StudentId);
            if (record == null) return "0001";
            int Id = int.Parse(record.StudentId);
            int IdDigits = Convert.ToInt32(Math.Floor(Math.Log10(Id) + 1));
            if (IdDigits >= 4)
            {
                return string.Format("{0}", Id + 1);
            }
            string zeros = new string('0', 4 - IdDigits);            
            return string.Format("{0}{1}",zeros , Id + 1);
        }
    }
}
