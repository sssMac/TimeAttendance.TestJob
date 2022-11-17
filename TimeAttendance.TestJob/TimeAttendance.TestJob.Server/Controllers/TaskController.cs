using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TimeAttendance.TestJob.BLL.Interfaces;
using TimeAttendance.TestJob.DAL.Models.Entities;
using TimeAttendance.TestJob.DAL.Models.ViewModels;
using TimeAttendance.TestJob.Server.Hubs;

namespace TimeAttendance.TestJob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IHubContext<TaskHub> _hubContext;

        public TaskController(ITaskService taskService, IHubContext<TaskHub> hubContext)
        {
            _taskService = taskService;
            _hubContext = hubContext;
        }

        #region Task
        [HttpGet("tasklist")]
        public async Task<ActionResult> GetTaskList(Guid id)
        {
            try
            {
                var tasks = (await _taskService.GetAllTasks());
                var comments = await _taskService.GetAllComments();

                var res = from task in tasks
                          where task.ProjectId == id
                          join com in comments
                          on task.Id equals com.TaskId
                          into Task
                          from comme in Task.DefaultIfEmpty()
                          select new { task, comme };

                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }


        [HttpPost("addnewtask")]
        public async Task<ActionResult> PostNewTask([FromForm]AddTask task)
        {
            try
            {
                var result = await _taskService.AddTask(task);

                if (result == null)
                {
                    return NotFound();
                }
                await _hubContext.Clients.All.SendAsync("TaskMessage", result);
                return Ok(result.task);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            return Ok();
        }

        [HttpGet("task")]
        public async Task<ActionResult> GetTask(Guid id)
        {
            try
            {
                var tasks = await _taskService.GetAllTasks();
                var comments = await _taskService.GetAllComments();

                var res = from task in tasks
                          where task.Id == id
                          join com in comments
                          on task.Id equals com.TaskId
                          into Task
                          from comme in Task.DefaultIfEmpty()
                          select new { task, comme };

                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpDelete("deletetask")]
        public async Task<ActionResult<SmallTask>> DeleteTask(Guid id)
        {
            try
            {
                var taskToDelete = await _taskService.GetTaskById(id);

                if (taskToDelete == null)
                {
                    return NotFound($"Task with Id = {id} not found");
                }

                return await _taskService.DeleteTask(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("updatetask")]
        public async Task<ActionResult> UpdateTask([FromForm]UpdateTask task)
        {
            try
            {
                var res = await _taskService.UpdateTask(task);
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        #endregion

        #region Comments
        [HttpGet("taskcommentslist")]
        public async Task<ActionResult> GetTaskCommentsList()
        {
            try
            {
                return Ok(await _taskService.GetAllComments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        #endregion
    }
}
