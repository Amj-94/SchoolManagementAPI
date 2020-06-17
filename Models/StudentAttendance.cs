using System;
namespace SchoolManagementAPI.Models
{
    public class StudentAttendance
    {
        public Guid StudentGUID { get; set; }
        public Guid EnrollmentAttendanceGUID { get; set; }
        public bool Value { get; set; }

        public virtual Student Student { get; set; }
        public virtual EnrollmentAttendance EnrollmentAttendances { get; set; }
    }
}
