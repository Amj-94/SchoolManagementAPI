using System;
using System.Threading.Tasks;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface IYearService
    {
        public string GetNewYearId();

        public YearDTO CreateYear(YearDTO yearDTO, string token);
    }
}
