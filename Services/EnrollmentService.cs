using System;
using System.Collections.Generic;
using AutoMapper;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using SchoolManagementAPI.ViewModels;
using System.Linq;

namespace SchoolManagementAPI.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppUserService _appUserService;
        private readonly IMasterService _masterService;

        public EnrollmentService(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          IAppUserService appUserService,
                                          IMasterService _masterService)
        {
            _unitOfWork = unitOfWork;
            _appUserService = appUserService;
            this._masterService = _masterService;
        }

        public EnrollmentSubjectDTO AddSubjectTests(Guid enrollmentSubjectGUID, EnrollmentSubjectTestDTO[] tests, string token)
        {
            var exist = _unitOfWork.GetReadOnlyRepository<EnrollmentSubject>().Single(x => x.EnrollmentSubjectGUID == enrollmentSubjectGUID);
            if (exist != null)
            {
                var enrollmentSubjectTests = _masterService.GetAll<EnrollmentSubjectTest>(x => x.EnrollmentSubjectGUID == enrollmentSubjectGUID).Items.ToList();

                foreach (EnrollmentSubjectTestDTO test in tests)
                {
                    if (enrollmentSubjectTests.Find(x => x.EnrollmentSubjectGUID == test.EnrollmentSubjectGUID && x.TestID == test.TestID) == null)
                    {
                        var newvalue = Mapper.Map<EnrollmentSubjectTest>(test);
                        newvalue.EnrollmentSubjectTestGUID = Guid.NewGuid();
                        //newvalue.CreatedBy = _appUserService.GetUserId(token);
                        var repo = _unitOfWork.GetRepository<EnrollmentSubjectTest>();
                        repo.Add(newvalue);
                        repo.SaveChanges();
                    }
                }
                return Mapper.Map<EnrollmentSubjectDTO>(_masterService.GetOne<EnrollmentSubject>(x => x.EnrollmentSubjectGUID == enrollmentSubjectGUID ));
            }
            throw new Exception("Enrollment Subject is not Exist");
        }

        public EnrollmentSubjectTestDTO AddSubjectTest(EnrollmentSubjectTestDTO value, string token)
        {            
            var enrollmentSubjecExist = _unitOfWork.GetReadOnlyRepository<EnrollmentSubject>().Single(x => x.EnrollmentSubjectGUID == value.EnrollmentSubjectGUID);
            if (enrollmentSubjecExist != null)
            {
                var enrollmentSubjectTest = _masterService.GetOne<EnrollmentSubjectTest>(x => x.TestID == value.TestID);
                if (enrollmentSubjectTest == null)
                {
                    var newvalue = Mapper.Map<EnrollmentSubjectTest>(value);
                    newvalue.EnrollmentSubjectTestGUID = Guid.NewGuid();
                    //ensbjtest.CreatedBy = _appUserService.GetUserId(token);
                    var repo = _unitOfWork.GetRepository<EnrollmentSubjectTest>();
                    repo.Add(newvalue);
                    repo.SaveChanges();
                    return Mapper.Map<EnrollmentSubjectTestDTO>(_masterService.GetOne<EnrollmentSubjectTest>(x => x.EnrollmentSubjectTestGUID == newvalue.EnrollmentSubjectTestGUID));
                }
                throw new Exception("This Test Is Exist");
            }
            throw new Exception("Enrollment Subject Is Not Exist");
        }

        public EnrollmentDTO AddSubject(EnrollmentSubjectDTO subject, string token)
        {
            var exist = _unitOfWork.GetReadOnlyRepository<Enrollment>().Single(x => x.EnrollmentGUID == subject.EnrollmentGUID);
            if (exist != null)
            {
                var enrollmentSubject = _masterService.GetOne<EnrollmentSubject>(x => x.EnrollmentGUID == subject.EnrollmentGUID && x.SubjectGUID == subject.SubjectGUID);

                if (enrollmentSubject == null)
                {
                    var newvalue = Mapper.Map<EnrollmentSubject>(subject);
                    newvalue.EnrollmentSubjectGUID = Guid.NewGuid();
                    //newvalue.CreatedBy = _appUserService.GetUserId(token);
                    var repo = _unitOfWork.GetRepository<EnrollmentSubject>();
                    repo.Add(newvalue);
                    repo.SaveChanges();
                    return Mapper.Map<EnrollmentDTO>(_masterService.GetOne<Enrollment>(x => x.EnrollmentGUID == subject.EnrollmentGUID));
                }
                throw new Exception("This subject Is Exist");
            }
            throw new Exception("Enrollment is not Exist");
        }

        public EnrollmentDTO AddSubjects(Guid enrollmentGUID, EnrollmentSubjectDTO[] subjects, string token)
        {
            var exist = _unitOfWork.GetReadOnlyRepository<Enrollment>().Single(x => x.EnrollmentGUID == enrollmentGUID);
            if (exist != null)
            {
                var enrollmentSubjects = _masterService.GetAll<EnrollmentSubject>(x => x.EnrollmentGUID == enrollmentGUID).Items.ToList();

                foreach (EnrollmentSubjectDTO subject in subjects )
                    {
                        if (enrollmentSubjects.Find(x => x.SubjectGUID == subject.SubjectGUID && x.EnrollmentGUID == subject.EnrollmentGUID) == null)
                        {
                            var newvalue = Mapper.Map<EnrollmentSubject>(subject);
                            newvalue.EnrollmentSubjectGUID = Guid.NewGuid();
                            //newvalue.CreatedBy = _appUserService.GetUserId(token);
                            var repo = _unitOfWork.GetRepository<EnrollmentSubject>();
                            repo.Add(newvalue);
                            repo.SaveChanges();
                        }
                    }
                return Mapper.Map<EnrollmentDTO>(_masterService.GetOne<Enrollment>(x => x.EnrollmentGUID == enrollmentGUID));
            }
            throw new Exception("Enrollment is not Exist");
        }

        public EnrollmentDTO CreateEnrollment(EnrollmentDTO value, string token)
        {
            try
            {
                var repo = _unitOfWork.GetRepository<Enrollment>();
                var newvalue = Mapper.Map<Enrollment>(value);
                newvalue.EnrollmentGUID = Guid.NewGuid();
                if (newvalue.EnrollmentCode == null) newvalue.EnrollmentCode = newvalue.EnrollmentId;
                //newvalue.CreatedBy = _appUserService.GetUserId(token);
                newvalue.CreationDate = DateTime.Now;
                repo.Add(newvalue);
                repo.SaveChanges();
                return Mapper.Map<EnrollmentDTO>(newvalue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetNewEnrollmentId()
        {
            var record = _unitOfWork.GetReadOnlyRepository<Enrollment>().Single(null, null, x => x.EnrollmentId);
            if (record == null) return "0001";
            int Id = int.Parse(record.EnrollmentId);
            int IdDigits = Convert.ToInt32(Math.Floor(Math.Log10(Id) + 1));
            if (IdDigits >= 4)
            {
                return string.Format("{0}", Id + 1);
            }
            string zeros = new string('0', 4 - IdDigits);
            return string.Format("{0}{1}", zeros, Id + 1);
        }

        public EnrollmentDTO GetEnrollmentDetails(string enrollmetId)
        {
            var enrollment = _masterService.GetOne<Enrollment>(x => x.EnrollmentId == enrollmetId);
            var students = _masterService.GetAll<StudentEnrollment>(x => x.EnrollmentGUID == enrollment.EnrollmentGUID).Items;
            List<Student> enrollmetnStudents = new List<Student>();
            foreach (StudentEnrollment student in students)
            {
                var enrollmentStudent = _masterService.GetOne<Student>(x => x.StudentGUID == student.StudentGUID);
                enrollmetnStudents.Add(enrollmentStudent);
                //enrollmetnStudents.Append(enrollmentStudent);
            }
            enrollment.EnrollmentStudents = enrollmetnStudents;

            var subjects = _masterService.GetAll<EnrollmentSubject>(x => x.EnrollmentGUID == enrollment.EnrollmentGUID).Items;
            List<Subject> enrollmentSubjects = new List<Subject>();
            foreach (EnrollmentSubject subject in subjects)
            {
                var enrollmentSubject = _masterService.GetOne<Subject>(x => x.SubjectGUID == subject.SubjectGUID);
                enrollmentSubjects.Add(enrollmentSubject);
            }
            enrollment.Subjects = enrollmentSubjects;
            return Mapper.Map<EnrollmentDTO>(enrollment);
        }

        //public EnrollmentDTO AddStudent(Guid enrollmentGUID, Guid student, string token)
        //{
        //    var exist = _unitOfWork.GetReadOnlyRepository<Enrollment>().Single(x => x.EnrollmentGUID == enrollmentGUID);
        //    if (exist != null)
        //    {
        //        var enrollmentStudent = _masterService.GetOne<EnrollmentStudent>(x => x.EnrollmentGUID == enrollmentGUID && x.StudentGUID == student);

        //        if (enrollmentStudent == null)
        //        {
        //            var enrollmentStd = new EnrollmentStudent
        //            {
        //                EnrollmentGUID = enrollmentGUID,
        //                StudentGUID = student,
        //                EnrollmentStudentGUID = Guid.NewGuid()
        //            };
        //            var repo = _unitOfWork.GetRepository<EnrollmentStudent>();
        //            repo.Add(enrollmentStd);
        //            repo.SaveChanges();
        //        }                
        //        return Mapper.Map<EnrollmentDTO>(_masterService.GetOne<Enrollment>(x => x.EnrollmentGUID == enrollmentGUID));
        //    }
        //    throw new Exception("Enrollment is not Exist");
        //}

        //public EnrollmentDTO AddStudents(Guid enrollmentGUID, List<Guid> students, string token)
        //{
        //    var exist = _unitOfWork.GetReadOnlyRepository<Enrollment>().Single(x => x.EnrollmentGUID == enrollmentGUID);
        //    if (exist != null)
        //    {
        //        var enrollmentStudents =_masterService.GetAll<EnrollmentStudent>(x => x.EnrollmentGUID == enrollmentGUID).Items.ToList();

        //        for (var i = 0; i < students.Count; i++)
        //        {
        //            if (enrollmentStudents.Find(x => x.EnrollmentStudentGUID == students[i]) == null)
        //            {
        //                var enrollmentStudent = new EnrollmentStudent
        //                {
        //                    EnrollmentGUID = enrollmentGUID,
        //                    StudentGUID = students[i],
        //                    EnrollmentStudentGUID = Guid.NewGuid()
        //                };
        //                var repo = _unitOfWork.GetRepository<EnrollmentStudent>();
        //                repo.Add(enrollmentStudent);
        //                repo.SaveChanges();
        //            }
        //        }
        //        return Mapper.Map<EnrollmentDTO>(_masterService.GetOne<Enrollment>(x => x.EnrollmentGUID == enrollmentGUID));
        //    }
        //    throw new Exception("Enrollment is not Exist");
        //}
    }
}
