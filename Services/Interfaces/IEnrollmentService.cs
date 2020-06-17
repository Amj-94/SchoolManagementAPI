using System;
using System.Collections.Generic;
using SchoolManagementAPI.ViewModels;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface IEnrollmentService
    {
        public string GetNewEnrollmentId();

        public EnrollmentDTO CreateEnrollment(EnrollmentDTO value, string token);

        public EnrollmentDTO AddSubject(EnrollmentSubjectDTO subject, string token);

        public EnrollmentDTO AddSubjects(Guid enrollmentGUID, EnrollmentSubjectDTO [] subjects, string token);

        public EnrollmentSubjectTestDTO AddSubjectTest(EnrollmentSubjectTestDTO value, string token);

        public EnrollmentSubjectDTO AddSubjectTests(Guid enrollmentSubjectGUID, EnrollmentSubjectTestDTO [] tests, string token);

        public EnrollmentDTO GetEnrollmentDetails(string enrollmetId);
    }
}
