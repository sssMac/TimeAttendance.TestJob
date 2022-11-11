using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAttendance.TestJob.BLL.Interfaces;
using TimeAttendance.TestJob.DAL.Interfaces;
using TimeAttendance.TestJob.DAL.Models;

namespace TimeAttendance.TestJob.BLL.Services
{
    public class ProjectService : IProjectService
    {
        public readonly IRepository<Project> _repository;
        public ProjectService(IRepository<Project> repository)
        {
            _repository = repository;
        }
        public async Task<Project> AddProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    throw new ArgumentNullException(nameof(project));
                }
                else
                {
                    return await _repository.InsertAsync(project);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Project> DeleteProject(Guid id)
        {
            try
            {
                var result = (await _repository.GetAllAsync()).Where(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    await _repository.DeleteAsync(result);
                    await _repository.SaveAsync();
                    return result;
                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Project> UpdateProject(Project project)
        {
            try
            {
                var result = (await _repository.GetAllAsync()).Where(x => x.Id == project.Id).FirstOrDefault();

                if (result != null)
                {
                    await _repository.UpdateAsync(result);

                    return result;
                }

                return null;
                
            }
            catch (Exception )
            {
                throw ;
            }
        }
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Project> GetProjectById(Guid id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
