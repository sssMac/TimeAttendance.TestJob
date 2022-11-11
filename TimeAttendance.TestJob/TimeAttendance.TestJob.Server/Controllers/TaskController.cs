﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeAttendance.TestJob.BLL.Interfaces;
using TimeAttendance.TestJob.DAL.Models;

namespace TimeAttendance.TestJob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskCommentsService _taskCommentsService;

        public TaskController(ITaskService projectService, ITaskCommentsService taskCommentsService)
        {
            _taskService = projectService;
            _taskCommentsService = taskCommentsService;
        }

        [HttpGet("tasklist")]
        public async Task<ActionResult> GetTaskList()
        {
            try
            {
                return Ok(await _taskService.GetAllTasks());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("task")]
        public async Task<ActionResult<SmallTask>> GetTask(Guid id)
        {
            try
            {
                var result = await _taskService.GetTaskById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
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

        [HttpPut("updateptask")]
        public async Task<ActionResult<SmallTask>> UpdateTask(Guid id, SmallTask task)
        {
            try
            {
                if (id != task.Id)
                {
                    return BadRequest("Task ID mismatch");
                }

                var taskToUpdate = await _taskService.GetTaskById(id);

                if (taskToUpdate == null)
                {
                    return NotFound($"Task with Id = {id} not found");
                }

                return await _taskService.UpdateTask(task);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpGet("taskcommentslist")]
        public async Task<ActionResult> GetTaskCommentsList()
        {
            try
            {
                return Ok(await _taskCommentsService.GetAllTaskComments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet("taskcomments")]
        public async Task<ActionResult<TaskComments>> GetTaskComments(Guid id)
        {
            try
            {
                var result = await _taskCommentsService.GetTaskCommentsById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpDelete("deletetaskcomments")]
        public async Task<ActionResult<TaskComments>> DeleteTaskComments(Guid id)
        {
            try
            {
                var taskCommentsToDelete = await _taskCommentsService.GetTaskCommentsById(id);

                if (taskCommentsToDelete == null)
                {
                    return NotFound($"TaskComments with Id = {id} not found");
                }

                return await _taskCommentsService.DeleteTaskComments(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("updateptaskcomments")]
        public async Task<ActionResult<TaskComments>> UpdateTaskComments(Guid id, TaskComments taskComments)
        {
            try
            {
                if (id != taskComments.Id)
                {
                    return BadRequest("TaskComments ID mismatch");
                }

                var taskCommentsToUpdate = await _taskCommentsService.GetTaskCommentsById(id);

                if (taskCommentsToUpdate == null)
                {
                    return NotFound($"TaskComments with Id = {id} not found");
                }

                return await _taskCommentsService.UpdateTaskComments(taskComments);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

    }
}