using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SchoolManagementAPI.DependencyInjection;
using SchoolManagementAPI.Helpers;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.ModelViews;
using SchoolManagementAPI.Services;
using SchoolManagementAPI.Services.Interfaces;
using SchoolManagementAPI.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace SchoolManagementAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCors();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddDbContext<SchoolDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))).AddUnitOfWork<SchoolDBContext>();
            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<SchoolDBContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            //services.AddTransient<SchoolDBContextSeedData>();

            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IYearService, YearService>();
            services.AddScoped<ISemesterService, SemesterService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();            

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AppUser, AppUsersDTO>();
                cfg.CreateMap<AppUsersDTO, AppUser>();
                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<Year, YearDTO>();
                cfg.CreateMap<Semester, SemesterDTO>();
                cfg.CreateMap<Grade, GradeDTO>();
                cfg.CreateMap<Teacher, TeacherDTO>();
                cfg.CreateMap<Subject, SubjectDTO>();
                cfg.CreateMap<Enrollment, EnrollmentDTO>();
                cfg.CreateMap<EnrollmentSubject, EnrollmentSubjectDTO>();
                cfg.CreateMap<StudentEnrollment, StudentEnrollmentDTO>();
                cfg.CreateMap<StudentSubjectScore, StudentSubjectScoreDTO>();
                cfg.ValidateInlineMaps = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            //.AllowCredentials()); This line causing crash in app but don't now why

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.InitializeAsync(app.ApplicationServices);

            //await SchoolDBContextSeedData.InitializeAsync(app.ApplicationServices);

            //_ = seeder.SeedData();
        }
    }
}
