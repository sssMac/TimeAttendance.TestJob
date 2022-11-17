using Microsoft.AspNetCore.SignalR;
using TimeAttendance.TestJob.DAL.Models.ViewModels;

namespace TimeAttendance.TestJob.Server.Hubs
{
    public class TaskHub : Hub
    {
        public Task TaskMessage(AddTask task)
        {
            return Clients.All.SendAsync("TaskMessage", task);
        }
    }
}
