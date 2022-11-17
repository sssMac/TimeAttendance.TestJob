using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAttendance.TestJob.DAL.Models.Entities;
using TimeAttendance.TestJob.DAL.Models.ViewModels;

namespace TimeAttendance.TestJob.BLL.Interfaces
{
    public interface ITaskService
    {
        public Task<AddTaskResponse> AddTask(AddTask task);
        public Task<AddCommentResponse> AddComment(AddTaskComments comment);
        public Task<SmallTask> DeleteTask(Guid id);
        public Task<UpdateTask> UpdateTask(UpdateTask task);
        public Task<IEnumerable<SmallTask>> GetAllTasks();
        public Task<IEnumerable<TaskComments>> GetAllComments();
        public Task<SmallTask> GetTaskById(Guid id);

    }
}
