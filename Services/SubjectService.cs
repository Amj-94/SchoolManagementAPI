using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.UnitOfWork;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppUserService _appUserService;
        private readonly SchoolDBContext _schoolDBContext;
        private readonly IMasterService _masterService;

        public SubjectService(IUnitOfWork<SchoolDBContext> unitOfWork,
                                          IAppUserService appUserService,
                                          SchoolDBContext schoolDBContext,
                                          IMasterService masterService)
        {
            _unitOfWork = unitOfWork;
            _appUserService = appUserService;
            _schoolDBContext = schoolDBContext;
            _masterService = masterService;
        }

        [Obsolete]
        public async Task<SubjectDTO> CreateSubject(SubjectDTO subjectDTO, string token)
        {
            try
            {
                var repo = _unitOfWork.GetRepository<Subject>();
                var newvalue = Mapper.Map<Subject>(subjectDTO);
                newvalue.CreationDate = DateTime.Now;
                newvalue.SubjectGUID = Guid.NewGuid();
                if (newvalue.SubjectCode == null) newvalue.SubjectCode = newvalue.SubjectId;
                newvalue.CreatedBy = _appUserService.GetUserId(token);
                repo.Add(newvalue);
                repo.SaveChanges();
                var result = await _schoolDBContext.Database.ExecuteSqlCommandAsync("exec SPCheckSubjects");
                var newSubject = _masterService.GetOne<Subject>
                    (x => x.SubjectId == newvalue.SubjectId);
                return Mapper.Map<SubjectDTO>(newSubject);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GetNewSubjectId()
        {
            var record = _unitOfWork.GetReadOnlyRepository<Subject>()
                .Single(null, null, x => x.SubjectId);
            if (record == null) return "01";
            int Id = int.Parse(record.SubjectId);
            int IdDigits = Convert.ToInt32(Math.Floor(Math.Log10(Id) + 1));
            if (IdDigits >= 4)
            {
                return string.Format("{0}", Id + 1);
            }
            string zeros = new string('0', 2 - IdDigits);
            return string.Format("{0}{1}", zeros, Id + 1);
        }
    }
}
