namespace TimeAttendance.TestJob.Server.Configurations
{
    public static class CorsConfiguration
    {
        public static IServiceCollection CorsRegister(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors();

            return services;
        }
        public static WebApplication CorsConfigure(this WebApplication app)
        {
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            return app;
        }
    }
}
