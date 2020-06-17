using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppClaims",
                columns: table => new
                {
                    ClaimCode = table.Column<string>(nullable: false),
                    ClaimName1 = table.Column<string>(nullable: true),
                    ClaimName2 = table.Column<string>(nullable: true),
                    ClaimGUID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppClaims", x => x.ClaimCode);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    GradeGUID = table.Column<Guid>(nullable: false),
                    GradeCode = table.Column<string>(nullable: false),
                    GradeName1 = table.Column<string>(nullable: false),
                    GradeName2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.UniqueConstraint("AK_Grades_GradeGUID", x => x.GradeGUID);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    SectionGUID = table.Column<Guid>(nullable: false),
                    SectionCode = table.Column<string>(nullable: false),
                    SectionName1 = table.Column<string>(nullable: false),
                    SectionName2 = table.Column<string>(nullable: true),
                    SectionSymbol = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.UniqueConstraint("AK_Sections_SectionGUID", x => x.SectionGUID);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    SemesterId = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    SemesterGUID = table.Column<Guid>(nullable: false),
                    SemesterCode = table.Column<string>(nullable: false),
                    SemesterName1 = table.Column<string>(nullable: false),
                    SemesterName2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.SemesterId);
                    table.UniqueConstraint("AK_Semesters_SemesterGUID", x => x.SemesterGUID);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    YearId = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    YearGUID = table.Column<Guid>(nullable: false),
                    YearCode = table.Column<string>(nullable: false),
                    YearName1 = table.Column<string>(nullable: false),
                    YearName2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Years", x => x.YearId);
                    table.UniqueConstraint("AK_Years_YearGUID", x => x.YearGUID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    TeacherGUID = table.Column<Guid>(nullable: false),
                    TeacherCode = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    TeacherName = table.Column<string>(maxLength: 50, nullable: false),
                    TeacherMobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    YearGUID = table.Column<Guid>(nullable: false),
                    SemesterGUID = table.Column<Guid>(nullable: false),
                    GradeGUID = table.Column<Guid>(nullable: false),
                    SectionGUID = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    EnrollmentId = table.Column<string>(nullable: true),
                    EnrollmentGUID = table.Column<Guid>(nullable: false),
                    EnrollmentCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.YearGUID, x.SemesterGUID, x.GradeGUID, x.SectionGUID });
                    table.UniqueConstraint("AK_Enrollments_EnrollmentGUID", x => x.EnrollmentGUID);
                    table.ForeignKey(
                        name: "FK_Enrollments_Grades_GradeGUID",
                        column: x => x.GradeGUID,
                        principalTable: "Grades",
                        principalColumn: "GradeGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Sections_SectionGUID",
                        column: x => x.SectionGUID,
                        principalTable: "Sections",
                        principalColumn: "SectionGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Semesters_SemesterGUID",
                        column: x => x.SemesterGUID,
                        principalTable: "Semesters",
                        principalColumn: "SemesterGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Years_YearGUID",
                        column: x => x.YearGUID,
                        principalTable: "Years",
                        principalColumn: "YearGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentAttendances",
                columns: table => new
                {
                    EnrollmentGUID = table.Column<Guid>(nullable: false),
                    AttendanceDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    EnrollmentAttendanceGUID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentAttendances", x => new { x.EnrollmentGUID, x.AttendanceDate });
                    table.UniqueConstraint("AK_EnrollmentAttendances_EnrollmentAttendanceGUID", x => x.EnrollmentAttendanceGUID);
                    table.ForeignKey(
                        name: "FK_EnrollmentAttendances_Enrollments_EnrollmentGUID",
                        column: x => x.EnrollmentGUID,
                        principalTable: "Enrollments",
                        principalColumn: "EnrollmentGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    StudentGUID = table.Column<Guid>(nullable: false),
                    StudentCode = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    StudentName = table.Column<string>(maxLength: 50, nullable: false),
                    StudentMobile = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(maxLength: 50, nullable: true),
                    FatherMobile = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(maxLength: 50, nullable: true),
                    MotherMobile = table.Column<string>(nullable: true),
                    BirthCity = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    EnrollmentGradeGUID = table.Column<Guid>(nullable: true),
                    EnrollmentSectionGUID = table.Column<Guid>(nullable: true),
                    EnrollmentSemesterGUID = table.Column<Guid>(nullable: true),
                    EnrollmentYearGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.UniqueConstraint("AK_Students_StudentGUID", x => x.StudentGUID);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Enrollments_EnrollmentYearGUID_EnrollmentSemesterGUID_EnrollmentGradeGUID_EnrollmentSectionGUID",
                        columns: x => new { x.EnrollmentYearGUID, x.EnrollmentSemesterGUID, x.EnrollmentGradeGUID, x.EnrollmentSectionGUID },
                        principalTable: "Enrollments",
                        principalColumns: new[] { "YearGUID", "SemesterGUID", "GradeGUID", "SectionGUID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<string>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    SubjectGUID = table.Column<Guid>(nullable: false),
                    SubjectCode = table.Column<string>(nullable: false),
                    ParentSubjectId = table.Column<string>(nullable: true),
                    SubjectName1 = table.Column<string>(nullable: true),
                    SubjectName2 = table.Column<string>(nullable: true),
                    General = table.Column<int>(nullable: false),
                    GLevel = table.Column<int>(nullable: false),
                    EnrollmentGradeGUID = table.Column<Guid>(nullable: true),
                    EnrollmentSectionGUID = table.Column<Guid>(nullable: true),
                    EnrollmentSemesterGUID = table.Column<Guid>(nullable: true),
                    EnrollmentYearGUID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                    table.UniqueConstraint("AK_Subjects_SubjectGUID", x => x.SubjectGUID);
                    table.ForeignKey(
                        name: "FK_Subjects_Subjects_ParentSubjectId",
                        column: x => x.ParentSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Enrollments_EnrollmentYearGUID_EnrollmentSemesterGUID_EnrollmentGradeGUID_EnrollmentSectionGUID",
                        columns: x => new { x.EnrollmentYearGUID, x.EnrollmentSemesterGUID, x.EnrollmentGradeGUID, x.EnrollmentSectionGUID },
                        principalTable: "Enrollments",
                        principalColumns: new[] { "YearGUID", "SemesterGUID", "GradeGUID", "SectionGUID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAttendances",
                columns: table => new
                {
                    StudentGUID = table.Column<Guid>(nullable: false),
                    EnrollmentAttendanceGUID = table.Column<Guid>(nullable: false),
                    Value = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttendances", x => new { x.StudentGUID, x.EnrollmentAttendanceGUID });
                    table.ForeignKey(
                        name: "FK_StudentAttendances_EnrollmentAttendances_EnrollmentAttendanceGUID",
                        column: x => x.EnrollmentAttendanceGUID,
                        principalTable: "EnrollmentAttendances",
                        principalColumn: "EnrollmentAttendanceGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAttendances_Students_StudentGUID",
                        column: x => x.StudentGUID,
                        principalTable: "Students",
                        principalColumn: "StudentGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrollments",
                columns: table => new
                {
                    StudentGUID = table.Column<Guid>(nullable: false),
                    EnrollmentGUID = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    StudentEnrollmentGUID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollments", x => new { x.StudentGUID, x.EnrollmentGUID });
                    table.UniqueConstraint("AK_StudentEnrollments_StudentEnrollmentGUID", x => x.StudentEnrollmentGUID);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Enrollments_EnrollmentGUID",
                        column: x => x.EnrollmentGUID,
                        principalTable: "Enrollments",
                        principalColumn: "EnrollmentGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Students_StudentGUID",
                        column: x => x.StudentGUID,
                        principalTable: "Students",
                        principalColumn: "StudentGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentSubjects",
                columns: table => new
                {
                    SubjectGUID = table.Column<Guid>(nullable: false),
                    EnrollmentGUID = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    EnrollmentSubjectGUID = table.Column<Guid>(nullable: false),
                    MinMark = table.Column<float>(nullable: false),
                    MaxMark = table.Column<float>(nullable: false),
                    Included = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentSubjects", x => new { x.SubjectGUID, x.EnrollmentGUID });
                    table.UniqueConstraint("AK_EnrollmentSubjects_EnrollmentSubjectGUID", x => x.EnrollmentSubjectGUID);
                    table.ForeignKey(
                        name: "FK_EnrollmentSubjects_Enrollments_EnrollmentGUID",
                        column: x => x.EnrollmentGUID,
                        principalTable: "Enrollments",
                        principalColumn: "EnrollmentGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollmentSubjects_Subjects_SubjectGUID",
                        column: x => x.SubjectGUID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentSubjectTests",
                columns: table => new
                {
                    TestID = table.Column<string>(nullable: false),
                    EnrollmentSubjectGUID = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    EnrollmentSubjectTestGUID = table.Column<Guid>(nullable: false),
                    TestName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    MinMark = table.Column<float>(nullable: false),
                    MaxMark = table.Column<float>(nullable: false),
                    Included = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentSubjectTests", x => new { x.TestID, x.EnrollmentSubjectGUID });
                    table.UniqueConstraint("AK_EnrollmentSubjectTests_EnrollmentSubjectTestGUID", x => x.EnrollmentSubjectTestGUID);
                    table.ForeignKey(
                        name: "FK_EnrollmentSubjectTests_EnrollmentSubjects_EnrollmentSubjectGUID",
                        column: x => x.EnrollmentSubjectGUID,
                        principalTable: "EnrollmentSubjects",
                        principalColumn: "EnrollmentSubjectGUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubjectScore",
                columns: table => new
                {
                    StudentGUID = table.Column<Guid>(nullable: false),
                    StudentEnrollmentGUID = table.Column<Guid>(nullable: false),
                    EnrollmentSubjectTestGUID = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditedBy = table.Column<string>(nullable: true),
                    LastTimeEdited = table.Column<DateTime>(nullable: false),
                    Score = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubjectScore", x => new { x.StudentGUID, x.StudentEnrollmentGUID, x.EnrollmentSubjectTestGUID });
                    table.ForeignKey(
                        name: "FK_StudentSubjectScore_EnrollmentSubjectTests_EnrollmentSubjectTestGUID",
                        column: x => x.EnrollmentSubjectTestGUID,
                        principalTable: "EnrollmentSubjectTests",
                        principalColumn: "EnrollmentSubjectTestGUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubjectScore_StudentEnrollments_StudentEnrollmentGUID",
                        column: x => x.StudentEnrollmentGUID,
                        principalTable: "StudentEnrollments",
                        principalColumn: "StudentEnrollmentGUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubjectScore_Students_StudentGUID",
                        column: x => x.StudentGUID,
                        principalTable: "Students",
                        principalColumn: "StudentGUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentAttendances_EnrollmentAttendanceGUID",
                table: "EnrollmentAttendances",
                column: "EnrollmentAttendanceGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentGUID",
                table: "Enrollments",
                column: "EnrollmentGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_EnrollmentId",
                table: "Enrollments",
                column: "EnrollmentId",
                unique: true,
                filter: "[EnrollmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_GradeGUID",
                table: "Enrollments",
                column: "GradeGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_SectionGUID",
                table: "Enrollments",
                column: "SectionGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_SemesterGUID",
                table: "Enrollments",
                column: "SemesterGUID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentSubjects_EnrollmentGUID",
                table: "EnrollmentSubjects",
                column: "EnrollmentGUID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentSubjects_EnrollmentSubjectGUID",
                table: "EnrollmentSubjects",
                column: "EnrollmentSubjectGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentSubjectTests_EnrollmentSubjectGUID",
                table: "EnrollmentSubjectTests",
                column: "EnrollmentSubjectGUID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentSubjectTests_EnrollmentSubjectTestGUID",
                table: "EnrollmentSubjectTests",
                column: "EnrollmentSubjectTestGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_GradeCode",
                table: "Grades",
                column: "GradeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_GradeGUID",
                table: "Grades",
                column: "GradeGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SectionCode",
                table: "Sections",
                column: "SectionCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SectionGUID",
                table: "Sections",
                column: "SectionGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SectionSymbol",
                table: "Sections",
                column: "SectionSymbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_SemesterCode",
                table: "Semesters",
                column: "SemesterCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_SemesterGUID",
                table: "Semesters",
                column: "SemesterGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttendances_EnrollmentAttendanceGUID",
                table: "StudentAttendances",
                column: "EnrollmentAttendanceGUID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_EnrollmentGUID",
                table: "StudentEnrollments",
                column: "EnrollmentGUID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_StudentEnrollmentGUID",
                table: "StudentEnrollments",
                column: "StudentEnrollmentGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentCode",
                table: "Students",
                column: "StudentCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentGUID",
                table: "Students",
                column: "StudentGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EnrollmentYearGUID_EnrollmentSemesterGUID_EnrollmentGradeGUID_EnrollmentSectionGUID",
                table: "Students",
                columns: new[] { "EnrollmentYearGUID", "EnrollmentSemesterGUID", "EnrollmentGradeGUID", "EnrollmentSectionGUID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectScore_EnrollmentSubjectTestGUID",
                table: "StudentSubjectScore",
                column: "EnrollmentSubjectTestGUID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectScore_StudentEnrollmentGUID",
                table: "StudentSubjectScore",
                column: "StudentEnrollmentGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ParentSubjectId",
                table: "Subjects",
                column: "ParentSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectCode",
                table: "Subjects",
                column: "SubjectCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectGUID",
                table: "Subjects",
                column: "SubjectGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_EnrollmentYearGUID_EnrollmentSemesterGUID_EnrollmentGradeGUID_EnrollmentSectionGUID",
                table: "Subjects",
                columns: new[] { "EnrollmentYearGUID", "EnrollmentSemesterGUID", "EnrollmentGradeGUID", "EnrollmentSectionGUID" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherCode",
                table: "Teachers",
                column: "TeacherCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherGUID",
                table: "Teachers",
                column: "TeacherGUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Years_YearCode",
                table: "Years",
                column: "YearCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Years_YearGUID",
                table: "Years",
                column: "YearGUID",
                unique: true);

            var sp1 = @"CREATE procedure SPMakeSubjectGeneral
                    	@SubjectId Varchar(50)
                        AS
                        SET NOCOUNT ON
                        DECLARE @Level tinyint
                        set @Level =(select GLevel from Subjects WHERE SubjectId=@SubjectId)
                        IF Exists(SELECT SubjectId FROM Subjects WHERE SubjectId LIKE (@SubjectId+'%')  AND SubjectId>@SubjectId) BEGIN
                            UPDATE Subjects SET General=1 WHERE SubjectId=@SubjectId
                            UPDATE Subjects SET ParentSubjectId=@SubjectId WHERE SubjectId>@SubjectId AND SubjectId LIKE (@SubjectId+'%')
                            UPDATE Subjects SET GLevel=@Level+1 WHERE SubjectId LIKE (@SubjectId+'%') AND SubjectId>@SubjectId
                        END ELSE UPDATE Subjects SET General=0 WHERE SubjectId=@SubjectId
                        ";

            migrationBuilder.Sql(sp1);

            var sp2 = @"CREATE  PROCEDURE SPCheckSubjects
                        AS
                        declare @Subject varchar(50)
                        declare Cur cursor FOR SELECT SubjectId From Subjects WHERE SubjectId<>'' order by SubjectId
                        open Cur
                        fetch next from Cur into @Subject
                        while @@fetch_status=0 begin
                            exec SPMakeSubjectGeneral @Subject
                            fetch next from Cur into @Subject
                        end
                        close Cur
                        deallocate Cur
                        ";
            migrationBuilder.Sql(sp2);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppClaims");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "StudentAttendances");

            migrationBuilder.DropTable(
                name: "StudentSubjectScore");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EnrollmentAttendances");

            migrationBuilder.DropTable(
                name: "EnrollmentSubjectTests");

            migrationBuilder.DropTable(
                name: "StudentEnrollments");

            migrationBuilder.DropTable(
                name: "EnrollmentSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Years");
        }
    }
}
