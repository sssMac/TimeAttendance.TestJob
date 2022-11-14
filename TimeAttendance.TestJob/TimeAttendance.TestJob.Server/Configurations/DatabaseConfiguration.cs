using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TimeAttendance.TestJob.DAL.Data;

namespace TimeAttendance.TestJob.Server.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection DataBaseRegister(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(config["DefaultConnection"],
                x => x.MigrationsAssembly("TimeAttendance.TestJob.DAL")));

            return services;
        }
    }
}
