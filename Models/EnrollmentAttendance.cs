using System;
using System.Collections.Generic;

namespace SchoolManagementAPI.Models
{
    public class EnrollmentAttendance : Base
    {
        public EnrollmentAttendance()
        {
            EnrollmentAttendanceGUID = Guid.NewGuid();
        }
        public Guid EnrollmentGUID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public Guid EnrollmentAttendanceGUID { get; set; }
        public virtual Enrollment Enrollment { get; set; }

        public List<StudentAttendance> StudentAttendances { get; set; }
    }
}
