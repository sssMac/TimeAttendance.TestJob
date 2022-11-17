using TimeAttendance.TestJob.Server.Hubs;

namespace TimeAttendance.TestJob.Server.Configurations
{
    public static class SignalRConfiguration
    {
        public static IServiceCollection RegisterSignalR(this IServiceCollection services)
        {
            services.AddSignalR();
            return services;
        }
        public static WebApplication ConfigureSignalR(this WebApplication app)
        {
            app.MapHub<TaskHub>("/taskhub");
            return app;
        }
    }
}
