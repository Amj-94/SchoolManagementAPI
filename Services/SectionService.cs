using System;
using AutoMapper;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services
{
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppUserService _appUserService;
        public SectionService(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          IAppUserService appUserService)
        {
            _unitOfWork = unitOfWork;
            _appUserService = appUserService;
        }

        public SectionDTO CreateSection(SectionDTO sectionDTO, string token)
        {
            try
            {
                var repo = _unitOfWork.GetRepository<Section>();
                var newvalue = Mapper.Map<Section>(sectionDTO);
                newvalue.CreationDate = DateTime.Now;
                newvalue.SectionGUID = Guid.NewGuid();
                if (newvalue.SectionCode == null) newvalue.SectionCode = newvalue.SectionId;
                if (newvalue.SectionSymbol == null) newvalue.SectionSymbol = newvalue.SectionId;
                //newvalue.CreatedBy = _appUserService.GetUserId(token);
                repo.Add(newvalue);
                repo.SaveChanges();
                return Mapper.Map<SectionDTO>(newvalue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetNewSectionId()
        {
            var record = _unitOfWork.GetReadOnlyRepository<Section>().Single(null, null, x => x.SectionId);
            if (record == null) return "0001";
            int Id = int.Parse(record.SectionId);
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
