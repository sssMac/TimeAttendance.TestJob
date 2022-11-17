using TimeAttendance.TestJob.BLL.Interfaces;
using TimeAttendance.TestJob.BLL.MapperProfiles;
using TimeAttendance.TestJob.BLL.Services;
using TimeAttendance.TestJob.DAL.Interfaces;
using TimeAttendance.TestJob.DAL.Models.Entities;
using TimeAttendance.TestJob.DAL.Repository;
using AutoMapper;
namespace TimeAttendance.TestJob.Server.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ServicesRegister(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddAntiforgery(o => o.HeaderName = "X-XSRF-TOKEN");

            services.AddAutoMapper(typeof(AppMappingProfile));
            services.AddTransient<IRepository<Project>, Repository<Project>>();
            services.AddTransient<IRepository<SmallTask>, Repository<SmallTask>>();
            services.AddTransient<IRepository<TaskComments>, Repository<TaskComments>>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITaskService, TaskService>();
            

            return services;
        }
    }
}
