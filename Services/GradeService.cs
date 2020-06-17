using System;
using AutoMapper;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services
{
    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppUserService _appUserService;
        public GradeService(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          IAppUserService appUserService)
        {
            _unitOfWork = unitOfWork;
            _appUserService = appUserService;
        }
        public GradeDTO CreateGrade(GradeDTO gradeDTO, string token)
        {
            try
            {
                var repo = _unitOfWork.GetRepository<Grade>();
                var newvalue = Mapper.Map<Grade>(gradeDTO);
                newvalue.CreationDate = DateTime.Now;
                newvalue.GradeGUID = Guid.NewGuid();
                if (newvalue.GradeCode == null) newvalue.GradeCode = newvalue.GradeId;
                //if (newvalue.GradeSymbol == null) newvalue.GradeSymbol = newvalue.GradeId;
                //newvalue.CreatedBy = _appUserService.GetUserId(token);
                repo.Add(newvalue);
                repo.SaveChanges();
                return Mapper.Map<GradeDTO>(newvalue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetNewGradeId()
        {
            var record = _unitOfWork.GetReadOnlyRepository<Grade>().Single(null, null, x => x.GradeId);
            if (record == null) return "0001";
            int Id = int.Parse(record.GradeId);
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
