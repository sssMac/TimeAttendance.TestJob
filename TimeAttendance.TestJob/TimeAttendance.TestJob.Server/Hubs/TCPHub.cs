using Microsoft.AspNetCore.SignalR;
using System.Text;
using System.Text.Json;
using TimeAttendance.TestJob.BLL.Interfaces;
using TimeAttendance.TestJob.DAL.Models;
using TimeAttendance.TestJob.Server.Hubs.SignalRModels;

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

        //public async Task SendTaskObj(JsonElement obj)
        public async Task SendTaskObj(string taskName ,string project ,string startDate ,string endDate, string commType ,string comm)
        {

            var task = new SmallTask
            {
                Id = Guid.NewGuid(),
                ProjectId = Guid.Parse(project),
                TaskName = taskName,
                StartDate = DateTime.Today.Add(TimeSpan.Parse(startDate)),
                CancelDate = DateTime.Today.Add(TimeSpan.Parse(endDate)),
                CreateDate = DateTime.Now,
                DeleteDate = default
            };

            //var comment = new TaskComments
            //{
            //    Id = Guid.NewGuid(),
            //    TaskId = task.Id,
            //    CommentType = model.commType == "file" ? (byte)0 : (byte)1, 
            //    //Content = Encoding.ASCII.GetBytes(model.comm)
            //var response = await _taskService.AddTask(obj);
            //await Clients.All.SendAsync("ReceiveTask", obj);

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
