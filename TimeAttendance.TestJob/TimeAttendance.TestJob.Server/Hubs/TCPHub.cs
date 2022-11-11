using Microsoft.AspNetCore.SignalR;
using TimeAttendance.TestJob.BLL.Interfaces;
using TimeAttendance.TestJob.DAL.Models;

namespace TimeAttendance.TestJob.Server.Hubs
{
    public class TCPHub : Hub
    {
        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;
        private readonly ITaskCommentsService _taskCommentsService;
        public TCPHub(IProjectService projectService, ITaskService taskService, ITaskCommentsService taskCommentsService)
        {
            _projectService = projectService;
            _taskService = taskService;
            _taskCommentsService = taskCommentsService;
        }

        public async Task SendTaskObj(SmallTask obj)
        {
            var response = await _taskService.AddTask(obj);
            await Clients.All.SendAsync("ReceiveTask", obj);
        }

        public async Task SendTaskCommentsObj(TaskComments obj)
        {
            var response = await _taskCommentsService.AddTaskComments(obj);
            await Clients.All.SendAsync("ReceiveTaskComments", obj);
        }

        public async Task SendProjectObj(Project obj)
        {
            var response = await _projectService.AddProject(obj);
            await Clients.All.SendAsync("ReceiveProject", obj);
        }

    }
}
