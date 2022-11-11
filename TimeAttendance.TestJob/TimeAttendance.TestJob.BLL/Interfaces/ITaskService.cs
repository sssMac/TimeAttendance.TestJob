using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAttendance.TestJob.DAL.Models;

namespace TimeAttendance.TestJob.BLL.Interfaces
{
    public interface ITaskService
    {
        public Task<SmallTask> AddTask(SmallTask task);
        public Task<SmallTask> DeleteTask(Guid id);
        public Task<SmallTask> UpdateTask(SmallTask task);
        public Task<IEnumerable<SmallTask>> GetAllTasks();
        public Task<SmallTask> GetTaskById(Guid id);

    }
}
