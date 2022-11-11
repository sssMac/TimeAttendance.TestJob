using TimeAttendance.TestJob.BLL.Interfaces;
using TimeAttendance.TestJob.BLL.Services;

namespace TimeAttendance.TestJob.Server.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ServicesRegister(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddAntiforgery(o => o.HeaderName = "X-XSRF-TOKEN");

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskCommentsService, TaskCommentsService>();
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
