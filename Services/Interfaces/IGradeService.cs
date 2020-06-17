using System;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface IGradeService
    {
        public string GetNewGradeId();

        public GradeDTO CreateGrade(GradeDTO gradeDTO, string token);
    }
}
