using TimeAttendance.TestJob.BLL.Interfaces;
using TimeAttendance.TestJob.BLL.Services;
using TimeAttendance.TestJob.DAL.Interfaces;
using TimeAttendance.TestJob.DAL.Models;
using TimeAttendance.TestJob.DAL.Repository;

namespace TimeAttendance.TestJob.Server.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ServicesRegister(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddAntiforgery(o => o.HeaderName = "X-XSRF-TOKEN");

            services.AddSignalR();
            services.AddTransient<IRepository<Project>, Repository<Project>>();
            services.AddTransient<IRepository<SmallTask>, Repository<SmallTask>>();
            services.AddTransient<IRepository<TaskComments>, Repository<TaskComments>>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITaskCommentsService, TaskCommentsService>();
            services.AddTransient<ITaskService, TaskService>();
            

            return services;
        }
    }
}
