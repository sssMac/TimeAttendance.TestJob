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
    public class TaskService : ITaskService
    {
        public readonly IRepository<SmallTask> _repository;
        public TaskService(IRepository<SmallTask> repository)
        {
            _repository = repository;
        }
        public async Task<SmallTask> AddTask(SmallTask task)
        {
            try
            {
                if (task == null)
                {
                    throw new ArgumentNullException(nameof(task));
                }
                else
                {
                    return await _repository.InsertAsync(task);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<SmallTask> DeleteTask(Guid id)
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
        public async Task<SmallTask> UpdateTask(SmallTask task)
        {
            try
            {
                var result = (await _repository.GetAllAsync()).Where(x => x.Id == task.Id).FirstOrDefault();

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
        public async Task<IEnumerable<SmallTask>> GetAllTasks()
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
        public async Task<SmallTask> GetTaskById(Guid id)
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
