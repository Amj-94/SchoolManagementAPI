using System;
using AutoMapper;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppUserService _appUserService;
        public SemesterService(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          IAppUserService appUserService)
        {
            _unitOfWork = unitOfWork;
            _appUserService = appUserService;
        }

        public SemesterDTO CreateSemester(SemesterDTO semesterDTO, string token)
        {
            try
            {
                var repo = _unitOfWork.GetRepository<Semester>();
                var newvalue = Mapper.Map<Semester>(semesterDTO);
                newvalue.CreationDate = DateTime.Now;
                newvalue.SemesterGUID = Guid.NewGuid();
                if (newvalue.SemesterCode == null) newvalue.SemesterCode = newvalue.SemesterId;
                //newvalue.CreatedBy = _appUserService.GetUserId(token);
                repo.Add(newvalue);
                repo.SaveChanges();
                return Mapper.Map<SemesterDTO>(newvalue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetNewSemesterId()
        {
            var record = _unitOfWork.GetReadOnlyRepository<Semester>().Single(null, null, x => x.SemesterId);
            if (record == null) return "0001";
            int Id = int.Parse(record.SemesterId);
            int IdDigits = Convert.ToInt32(Math.Floor(Math.Log10(Id) + 1));
            if (IdDigits >= 4)
            {
                return string.Format("{0}", Id + 1);
            }
            string zeros = new string('0', 4 - IdDigits);
            return string.Format("{0}{1}", zeros, Id + 1);
        }
    }
}
