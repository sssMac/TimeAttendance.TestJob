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
    public class TaskCommentsService : ITaskCommentsService
    {
        public readonly IRepository<TaskComments> _repository;
        public TaskCommentsService(IRepository<TaskComments> repository)
        {
            _repository = repository;
        }
        public async Task<TaskComments> AddTaskComments(TaskComments taskComments)
        {
            try
            {
                if (taskComments == null)
                {
                    throw new ArgumentNullException(nameof(taskComments));
                }
                else
                {
                    return await _repository.InsertAsync(taskComments);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TaskComments> DeleteTaskComments(Guid id)
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
        public async Task<TaskComments> UpdateTaskComments(TaskComments taskComments)
        {
            try
            {
                var result = (await _repository.GetAllAsync()).Where(x => x.Id == taskComments.Id).FirstOrDefault();

                if (result != null)
                {
                    await _repository.UpdateAsync(result);

                    return result;
                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<TaskComments>> GetAllTaskComments()
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
        public async Task<TaskComments> GetTaskCommentsById(Guid id)
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
