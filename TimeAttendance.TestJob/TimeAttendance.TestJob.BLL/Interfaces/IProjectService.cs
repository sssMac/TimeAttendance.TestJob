using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAttendance.TestJob.DAL.Models;

namespace TimeAttendance.TestJob.BLL.Interfaces
{
    public interface IProjectService
    {
        public Task<Project> AddProject(Project project);
        public Task<Project> DeleteProject(Guid id);
        public Task<Project> UpdateProject(Project project);
        public Task<IEnumerable<Project>> GetAllProjects();
        public Task<Project> GetProjectById(Guid id);

    }
}
