using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeAttendance.TestJob.BLL.Interfaces;
using TimeAttendance.TestJob.DAL.Models.Entities;

namespace TimeAttendance.TestJob.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("projectlist")]
        public async Task<ActionResult> GetProjectList()
        {
            try
            {
                return Ok(await _projectService.GetAllProjects());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> PostNewProject(Project model)
        {
            await _projectService.AddProject(model);
            return Ok();
        }

        [HttpGet("project")]
        public async Task<ActionResult<Project>> GetProject(Guid id)
        {
            try
            {
                var result = await _projectService.GetProjectById(id);

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

        [HttpDelete("deleteproject")]
        public async Task<ActionResult<Project>> DeleteProject(Guid id)
        {
            try
            {
                var projectToDelete = await _projectService.GetProjectById(id);

                if (projectToDelete == null)
                {
                    return NotFound($"Project with Id = {id} not found");
                }

                return await _projectService.DeleteProject(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut("updateproject")]
        public async Task<ActionResult<Project>> UpdateProject(Guid id, Project project)
        {
            try
            {
                if (id != project.Id)
                {
                    return BadRequest("Project ID mismatch");
                }

                var projectToUpdate = await _projectService.GetProjectById(id);

                if (projectToUpdate == null)
                {
                    return NotFound($"Project with Id = {id} not found");
                }

                return await _projectService.UpdateProject(project);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
    }
}
