using System;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface ISemesterService
    {
        public string GetNewSemesterId();

        public SemesterDTO CreateSemester(SemesterDTO semesterDTO, string token);
    }
}
