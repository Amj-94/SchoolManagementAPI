using System;
using System.Threading.Tasks;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface IStudentService
    {
        public string GetNewStudentId();

        public Task<StudentDTO> CreateStudent(StudentDTO studentDTO, string token);

        public StudentEnrollmentDTO AddStudentEnrollment(StudentEnrollmentDTO value, string token);

        public StudentSubjectScoreDTO AddStudentSubjectScore(StudentSubjectScoreDTO value, string token);
    }
}
