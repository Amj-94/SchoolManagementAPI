using System;
using System.Threading.Tasks;
using AutoMapper;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services
{
    public class YearService : IYearService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppUserService _appUserService;
        private readonly IMasterService _masterService;

        public YearService(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          IAppUserService appUserService,
                                          IMasterService masterService)
        {
            _unitOfWork = unitOfWork;
            _appUserService = appUserService;
            _masterService = masterService;
        }

        public YearDTO CreateYear(YearDTO yearDTO, string token)
        {
            var exist = _masterService.GetOne<Year>(x => x.YearId == yearDTO.YearId);
            if (exist == null)
            {
                try
                {
                    var repo = _unitOfWork.GetRepository<Year>();
                    var newvalue = Mapper.Map<Year>(yearDTO);
                    newvalue.CreationDate = DateTime.Now;
                    newvalue.YearGUID = Guid.NewGuid();
                    if (newvalue.YearCode == null) newvalue.YearCode = newvalue.YearId;
                    //newvalue.CreatedBy = _appUserService.GetUserId(token);
                    repo.Add(newvalue);
                    repo.SaveChanges();
                    return Mapper.Map<YearDTO>(newvalue);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return null;
        }

        public string GetNewYearId()
        {
            var record = _unitOfWork.GetReadOnlyRepository<Year>().Single(null, null, x => x.YearId);
            if (record == null) return "0001";
            int Id = int.Parse(record.YearId);
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
