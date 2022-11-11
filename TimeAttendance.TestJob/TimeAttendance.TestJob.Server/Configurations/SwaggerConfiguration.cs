namespace TimeAttendance.TestJob.Server.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection SwaggerRegister(this IServiceCollection services)
        {
            services.AddSwaggerGen();

            return services;
        }
        public static WebApplication SwaggerConfigure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            return app;
        }
    }
}
