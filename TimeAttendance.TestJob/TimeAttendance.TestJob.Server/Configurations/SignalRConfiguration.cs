using TimeAttendance.TestJob.Server.Hubs;

namespace TimeAttendance.TestJob.Server.Configurations
{
    public static class SignalRConfiguration
    {
        public static WebApplication SignalRConfigure(this WebApplication app)
        {

            app.MapHub<TCPHub>("/websocket");

            return app;
        }
    }
}
