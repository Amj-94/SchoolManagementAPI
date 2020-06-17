using System;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface ISectionService
    {
        public string GetNewSectionId();

        public SectionDTO CreateSection(SectionDTO sectionDTO, string token);
    }
}
