using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAttendance.TestJob.DAL.Models;

namespace TimeAttendance.TestJob.BLL.Interfaces
{
    public interface ITaskCommentsService
    {
        public Task<TaskComments> AddTaskComments(TaskComments taskComments);
        public Task<TaskComments> DeleteTaskComments(Guid id);
        public Task<TaskComments> UpdateTaskComments(TaskComments taskComments);
        public Task<IEnumerable<TaskComments>> GetAllTaskComments();
        public Task<TaskComments> GetTaskCommentsById(Guid id);

    }
}
