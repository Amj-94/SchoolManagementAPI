using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementAPI.Models
{
    public class SchoolDBContext : IdentityDbContext<AppUser>
    {
        public SchoolDBContext()
        {

        }
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options)
            : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppClaim> AppClaims { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<EnrollmentAttendance> EnrollmentAttendances { get; set; }
        public DbSet<EnrollmentSubject> EnrollmentSubjects { get; set; }
        public DbSet<EnrollmentSubjectTest> EnrollmentSubjectTests { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<StudentEnrollment> StudentEnrollments { get; set; }
        public DbSet<StudentSubjectScore> StudentSubjectScore { get; set; }

        public SchoolDBContext CreateDbContext(string[] args)
        {
            //MacBook Server
            //return new SchoolDBContext(SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<SchoolDBContext>(),
            //    "Server=localhost,1433\\Catalog=Sample;Database=Sample2;User=SA;Password=Savage@123").Options);

            //Front End Server
            //return new SchoolDBContext(SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<SchoolDBContext>(),
            //"Server=MAHMOUD-KASSAH\\SQLEXPRESS,1433\\Catalog=Sample1;Database=Sample1;User=SA;Password=Savage@123;").Options);

            ////2014 SQL Server
            //return new SchoolDBContext(SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<SchoolDBContext>(),
            //    "Server=192.168.0.33\\SQL2014INSTANCE,1433\\Catalog=Sample1;Database=Sample1;User=SA;Password=Savage@123;").Options);

            //Host
            return new SchoolDBContext(SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<SchoolDBContext>(),
            "Server=SQL5046.site4now.net;Initial Catalog=DB_A630F3_Amj94ba;User Id=DB_A630F3_Amj94ba_admin;Password=nRCz4k4y#_zjqR5;").Options);

            //Local Host
            //return new SchoolDBContext(SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<SchoolDBContext>(),
            //"Server=DESKTOP-JJ2MQTL\\SQL2014Instance,1433\\Catalog=Sample1;Database=Sample1;User=SA;Password=Savage@123;").Options);

            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var coonectionString = "Server=192.168.0.33\\SQL2008INSTANCE,1433\\Catalog=Sample1;Database=Sample1;User=SA;Password=Savage@123;";
        //    optionsBuilder.UseSqlServer(coonectionString, builder => builder.UseRowNumberForPaging());
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().HasIndex(u => u.UserName).IsUnique();

            builder.Entity<Year>().HasIndex(u => u.YearGUID).IsUnique();
            builder.Entity<Year>().HasIndex(u => u.YearCode).IsUnique();

            builder.Entity<Semester>().HasIndex(u => u.SemesterGUID).IsUnique();
            builder.Entity<Semester>().HasIndex(u => u.SemesterCode).IsUnique();

            builder.Entity<Grade>().HasIndex(u => u.GradeGUID).IsUnique();
            builder.Entity<Grade>().HasIndex(u => u.GradeCode).IsUnique();

            builder.Entity<Section>().HasIndex(u => u.SectionGUID).IsUnique();
            builder.Entity<Section>().HasIndex(u => u.SectionCode).IsUnique();
            builder.Entity<Section>().HasIndex(u => u.SectionSymbol).IsUnique();

            builder.Entity<Student>().HasIndex(u => u.StudentGUID).IsUnique();
            builder.Entity<Student>().HasIndex(u => u.StudentCode).IsUnique();

            builder.Entity<Teacher>().HasIndex(u => u.TeacherGUID).IsUnique();
            builder.Entity<Teacher>().HasIndex(u => u.TeacherCode).IsUnique();

            builder.Entity<Subject>().HasIndex(u => u.SubjectGUID).IsUnique();
            builder.Entity<Subject>().HasIndex(u => u.SubjectCode).IsUnique();

            builder.Entity<Enrollment>().HasKey(u =>
            new { u.YearGUID, u.SemesterGUID, u.GradeGUID, u.SectionGUID });

            builder.Entity<Enrollment>().HasIndex(u => u.EnrollmentId).IsUnique();
            builder.Entity<Enrollment>().HasIndex(u => u.EnrollmentGUID).IsUnique();

            builder.Entity<Enrollment>().HasOne(u => u.Year)
                                        .WithMany(Y => Y.Enrollments)
                                        .HasForeignKey(u => u.YearGUID)
                                        .HasPrincipalKey(y => y.YearGUID);

            builder.Entity<Enrollment>().HasOne(u => u.Semester)
                                        .WithMany(s => s.Enrollments)
                                        .HasForeignKey(u => u.SemesterGUID)
                                        .HasPrincipalKey(s => s.SemesterGUID);

            builder.Entity<Enrollment>().HasOne(u => u.Grade)
                                        .WithMany(g => g.Enrollments)
                                        .HasForeignKey(u => u.GradeGUID)
                                        .HasPrincipalKey(g => g.GradeGUID);

            builder.Entity<Enrollment>().HasOne(u => u.Section)
                                        .WithMany(s => s.Enrollments)
                                        .HasForeignKey(u => u.SectionGUID)
                                        .HasPrincipalKey(s => s.SectionGUID);

            builder.Entity<EnrollmentAttendance>().HasKey(u => new { u.EnrollmentGUID, u.AttendanceDate });
            builder.Entity<EnrollmentAttendance>().HasIndex(u => u.EnrollmentAttendanceGUID).IsUnique();

            builder.Entity<EnrollmentAttendance>().HasOne(u => u.Enrollment)
                                                  .WithMany(e => e.EnrollmentAttendances)
                                                  .HasForeignKey(u => u.EnrollmentGUID)
                                                  .HasPrincipalKey(e => e.EnrollmentGUID);

            builder.Entity<EnrollmentSubject>().HasKey(u => new { u.SubjectGUID, u.EnrollmentGUID });
            builder.Entity<EnrollmentSubject>().HasIndex(u => u.EnrollmentSubjectGUID).IsUnique();

            builder.Entity<EnrollmentSubject>().HasOne(s => s.Subject)
                                               .WithMany(u => u.EnrollmentSubjects)
                                               .HasForeignKey(s => s.SubjectGUID)
                                               .HasPrincipalKey(u => u.SubjectGUID);

            builder.Entity<EnrollmentSubject>().HasOne(s => s.Enrollment)
                                               .WithMany(u => u.EnrollmentSubjects)
                                               .HasForeignKey(s => s.EnrollmentGUID)
                                               .HasPrincipalKey(u => u.EnrollmentGUID);

            builder.Entity<EnrollmentSubjectTest>().HasKey(u =>
                new { u.TestID, u.EnrollmentSubjectGUID });

            builder.Entity<EnrollmentSubjectTest>().HasIndex(u => u.EnrollmentSubjectTestGUID).IsUnique();

            builder.Entity<EnrollmentSubjectTest>().HasOne(u => u.EnrollmentSubject)
                                                   .WithMany(s => s.EnrollmentSubjectTests)
                                                   .HasForeignKey(u => u.EnrollmentSubjectGUID)
                                                   .HasPrincipalKey(u => u.EnrollmentSubjectGUID);

            builder.Entity<StudentAttendance>().HasKey(u => new { u.StudentGUID, u.EnrollmentAttendanceGUID });

            builder.Entity<StudentAttendance>().HasOne(u => u.Student)
                                               .WithMany(s => s.StudentAttendances)
                                               .HasForeignKey(u => u.StudentGUID)
                                               .HasPrincipalKey(s => s.StudentGUID);

            builder.Entity<StudentAttendance>().HasOne(u => u.EnrollmentAttendances)
                                               .WithMany(e => e.StudentAttendances)
                                               .HasForeignKey(u => u.EnrollmentAttendanceGUID)
                                               .HasPrincipalKey(e => e.EnrollmentAttendanceGUID);

            builder.Entity<StudentEnrollment>().HasKey(u => new { u.StudentGUID, u.EnrollmentGUID });
            builder.Entity<StudentEnrollment>().HasIndex(u => u.StudentEnrollmentGUID).IsUnique();

            builder.Entity<StudentEnrollment>().HasOne(u => u.Student)
                                               .WithMany(s => s.StudentEnrollments)
                                               .HasForeignKey(u => u.StudentGUID)
                                               .HasPrincipalKey(s => s.StudentGUID);

            builder.Entity<StudentEnrollment>().HasOne(u => u.Enrollment)
                                               .WithMany(e => e.StudentEnrollments)
                                               .HasForeignKey(u => u.EnrollmentGUID)
                                               .HasPrincipalKey(e => e.EnrollmentGUID);


            builder.Entity<StudentSubjectScore>().HasKey(u =>
            new { u.StudentGUID, u.StudentEnrollmentGUID, u.EnrollmentSubjectTestGUID });

            builder.Entity<StudentSubjectScore>().HasOne(u => u.Student)
                                                 .WithMany(s => s.StudentSubjectScores)
                                                 .HasForeignKey(u => u.StudentGUID)
                                                 .HasPrincipalKey(s => s.StudentGUID)
                                                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentSubjectScore>().HasOne(u => u.StudentEnrollment)
                                                 .WithMany(s => s.StudentSubjectScores)
                                                 .HasForeignKey(u => u.StudentEnrollmentGUID)
                                                 .HasPrincipalKey(s => s.StudentEnrollmentGUID)
                                                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<StudentSubjectScore>().HasOne(u => u.EnrollmentSubjectTest)
                                                 .WithMany(e => e.StudentSubjectScores)
                                                 .HasForeignKey(u => u.EnrollmentSubjectTestGUID)
                                                 .HasPrincipalKey(e => e.EnrollmentSubjectTestGUID);






            //builder.Entity<EnrollmentStudent>().HasKey(u => new { u.StudentGUID, u.EnrollmentGUID });
            //builder.Entity<EnrollmentStudent>().HasIndex(u => u.EnrollmentStudentGUID).IsUnique();

            //builder.Entity<EnrollmentStudent>().HasOne(s => s.Student)
            //                                   .WithMany(u => u.EnrollmentStudents)
            //                                   .HasForeignKey(s => s.StudentGUID)
            //                                   .HasPrincipalKey(u => u.StudentGUID);

            //builder.Entity<EnrollmentStudent>().HasOne(s => s.Enrollment)
            //                                   .WithMany(u => u.EnrollmentStudents)
            //                                   .HasForeignKey(s => s.EnrollmentGUID)
            //                                   .HasPrincipalKey(u => u.EnrollmentGUID);


            //builder.Entity<ScoreRecordDetail>().HasKey(u => new { u.EnrollmentStudentGUID, u.EnrollmentSubjectGUID});
            //builder.Entity<ScoreRecordDetail>().HasIndex(u => u.ScoreRecordDetailGuid).IsUnique();            

            //builder.Entity<ScoreRecordDetail>().HasOne(s => s.EnrollmentStudent)
            //                                   .WithMany(u => u.ScoreRecordDetails)
            //                                   .HasForeignKey(s => s.EnrollmentStudentGUID)
            //                                   .HasPrincipalKey(u => u.EnrollmentStudentGUID)
            //                                   .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<ScoreRecordDetail>().HasOne(s => s.EnrollmentSubject)
            //                                   .WithMany(u => u.ScoreRecordDetails)
            //                                   .HasForeignKey(s => s.EnrollmentSubjectGUID)
            //                                   .HasPrincipalKey(u => u.EnrollmentSubjectGUID);

            //builder.Entity<AppClaim>().HasIndex(u => u.ClaimGUID).IsUnique();

            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole { Id = "01", Name = "Owner", NormalizedName = "OWNER" },
            //    new IdentityRole { Id = "02", Name = "Admin", NormalizedName = "ADMIN" },
            //    new IdentityRole { Id = "03", Name = "Staff", NormalizedName = "STAFF" },
            //    new IdentityRole { Id = "04", Name = "Parent", NormalizedName = "Parent" },
            //    new IdentityRole { Id = "05", Name = "Student", NormalizedName = "Student" }
            //);

            //AppUser appUser = new AppUser
            //{
            //    UserName = "SuperVisor",
            //    Email = "tester@test.com",
            //    NormalizedEmail = "tester@test.com".ToUpper(),
            //    NormalizedUserName = "tester".ToUpper(),
            //    TwoFactorEnabled = false,
            //    EmailConfirmed = true,
            //    PhoneNumber = "123456789",
            //    PhoneNumberConfirmed = false
            //};            

            //PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            //appUser.PasswordHash = ph.HashPassword(appUser, "P@ssw0rd");
            
            //builder.Entity<AppUser>().HasData(
            //    appUser
            //);

            //builder.Entity<Subject>().HasData(new { SubjectId = "", SubjectName = "" });

            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "01", ClaimName1 = "Years", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0101", ClaimName1 = "CreateYear", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0102", ClaimName1 = "ReadYear", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0103", ClaimName1 = "UpdateYear", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0104", ClaimName1 = "DeleteYear", ClaimGUID = Guid.NewGuid() });

            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "02", ClaimName1 = "Semesters", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0201", ClaimName1 = "CreateSemester", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0202", ClaimName1 = "ReadSemester", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0203", ClaimName1 = "UpdateSemester", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0204", ClaimName1 = "DeleteSemester", ClaimGUID = Guid.NewGuid() });

            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "03", ClaimName1 = "Grades", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0301", ClaimName1 = "CreateGrade", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0302", ClaimName1 = "ReadGrade", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0303", ClaimName1 = "UpdateGrade", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0304", ClaimName1 = "DeleteGrade", ClaimGUID = Guid.NewGuid() });

            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "04", ClaimName1 = "Sections", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0401", ClaimName1 = "CreateSection", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0402", ClaimName1 = "ReadSection", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0403", ClaimName1 = "UpdateSection", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0404", ClaimName1 = "DeleteSection", ClaimGUID = Guid.NewGuid() });

            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "05", ClaimName1 = "Students", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0501", ClaimName1 = "CreateStudent", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0502", ClaimName1 = "ReadStudent", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0503", ClaimName1 = "UpdateStudent", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0504", ClaimName1 = "DeleteStudent", ClaimGUID = Guid.NewGuid() });

            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "06", ClaimName1 = "Teachers", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0601", ClaimName1 = "Teachers", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0602", ClaimName1 = "Teachers", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0603", ClaimName1 = "Teachers", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0604", ClaimName1 = "Teachers", ClaimGUID = Guid.NewGuid() });

            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "07", ClaimName1 = "Subjects", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0701", ClaimName1 = "CreateSubject", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0702", ClaimName1 = "ReadSubject", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0703", ClaimName1 = "UpdateSubject", ClaimGUID = Guid.NewGuid() });
            //builder.Entity<AppUserClaim>().HasData(new { ClaimCode = "0704", ClaimName1 = "DeleteSubject", ClaimGUID = Guid.NewGuid() });           


            //var hasher = new PasswordHasher<AppUser>();

            //builder.Entity<AppUser>().HasData(new AppUser
            //{   Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
            //    UserName = "Admin",
            //    NormalizedUserName = "admin",
            //    Email = "some-admin-email@nonce.fake",
            //    NormalizedEmail = "some-admin-email@nonce.fake",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
            //    SecurityStamp = string.Empty,
            //    UserCategory = "01"});
            //builder.Entity<Grade>().HasData(new { Id = 1, GradeCode = "", GradeyName = "General", CreateionDate = DateTime.Now });
            //builder.Entity<UserCategory>().HasData(new { CategoryId = "04", CategoryName = "Students" });
        }
    }
}
