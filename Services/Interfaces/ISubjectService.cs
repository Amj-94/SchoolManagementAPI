using System;
using System.Threading.Tasks;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface ISubjectService
    {
        public string GetNewSubjectId();

        public Task<SubjectDTO> CreateSubject(SubjectDTO subjectDTO, string token);
    }
}
