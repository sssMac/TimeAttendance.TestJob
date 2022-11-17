using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using System.Text;
using TimeAttendance.TestJob.BLL.Interfaces;
using TimeAttendance.TestJob.DAL.Interfaces;
using TimeAttendance.TestJob.DAL.Models.Entities;
using TimeAttendance.TestJob.DAL.Models.ViewModels;

namespace TimeAttendance.TestJob.BLL.Services
{
    public class TaskService : ITaskService
    {
        public readonly IRepository<SmallTask> _taskRepository;
        public readonly IRepository<TaskComments> _commentsRepository;
        private readonly IMapper _mapper;
        public TaskService(IRepository<SmallTask> taskRepository, IMapper mapper, IRepository<TaskComments> commentsRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _commentsRepository = commentsRepository;
        }
        public async Task<AddTaskResponse> AddTask(AddTask task)
        {
            try
            {
                if (task != null)
                {
                    var newTask = _mapper.Map<SmallTask>(task);
                    var taskComment = new TaskComments();

                    newTask.Id = Guid.NewGuid();
                    newTask.CreateDate = DateTime.Now;

                    if (task.CommentType != "")
                    {
                        taskComment.Id = Guid.NewGuid();
                        taskComment.TaskId = newTask.Id;

                        if (task.CommentType == "text")
                        {
                            taskComment.CommentType = (byte)0;
                            taskComment.Content = Encoding.ASCII.GetBytes(task.StringContent);
                        }
                        else
                        {
                            taskComment.CommentType = (byte)1;
                            using (var ms = new MemoryStream())
                            {
                                await task.FileContent.CopyToAsync(ms);
                                taskComment.Content = ms.ToArray();
                            }
                        }

                        await _commentsRepository.InsertAsync(taskComment);

                    }
                    await _taskRepository.InsertAsync(newTask);

                    return new AddTaskResponse { task = newTask, comme = taskComment };
                }

                throw new ArgumentNullException(nameof(task));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AddCommentResponse> AddComment(AddTaskComments comment)
        {
            try
            {
                if (comment != null)
                {
                    var taskComment = new TaskComments();

                    if (comment.CommentType != "")
                    {
                        taskComment.Id = Guid.NewGuid();
                        taskComment.TaskId = comment.TaskId;

                        if (comment.CommentType == "text")
                        {
                            taskComment.CommentType = (byte)0;
                            taskComment.Content = Encoding.ASCII.GetBytes(comment.StringContent);
                        }
                        else
                        {
                            taskComment.CommentType = (byte)1;
                            using (var ms = new MemoryStream())
                            {
                                await comment.FileContent.CopyToAsync(ms);
                                taskComment.Content = ms.ToArray();
                            }
                        }

                        await _commentsRepository.InsertAsync(taskComment);

                    }

                    return new AddCommentResponse { comme = taskComment };
                }

                throw new ArgumentNullException(nameof(comment));

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
                var result = (await _taskRepository.GetAllAsync()).Where(x => x.Id == id).FirstOrDefault();
                if (result != null)
                {
                    await _taskRepository.DeleteAsync(result);
                    await _taskRepository.SaveAsync();
                    return result;
                }

                return null;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<UpdateTask> UpdateTask(UpdateTask task)
        {
            try
            {
                var updateTask = _mapper.Map<SmallTask>(task);
                await _taskRepository.UpdateAsync(updateTask);

                var updateComment = new TaskComments();

                if (task.CommentType == null && task.CommentId != null)
                {
                    await _commentsRepository.DeleteAsync(Guid.Parse(task.CommentId));
                }
                else if (task.CommentType != "")
                {
                    updateComment.TaskId = Guid.Parse(task.Id);

                    if (task.CommentType == "text")
                    {
                        if(task.CommentId == null) { 
                            updateComment.Id = Guid.NewGuid();
                        }
                        else { updateComment.Id = Guid.Parse(task.CommentId); }

                        updateComment.CommentType = 0;
                        updateComment.Content = Encoding.ASCII.GetBytes(task.StringContent);

                    }
                    else
                    {
                        if (task.CommentId == null) { 
                            updateComment.Id = Guid.NewGuid();

                        }
                        else { updateComment.Id = Guid.Parse(task.CommentId); }

                        updateComment.CommentType = 1;
                        using (var ms = new MemoryStream())
                        {
                            await task.FileContent.CopyToAsync(ms);
                            updateComment.Content = ms.ToArray();
                        }

                    }
                    if (task.CommentId == null)
                    {
                        await _commentsRepository.InsertAsync(updateComment);

                    }
                    else
                    {
                        await _commentsRepository.UpdateAsync(updateComment);

                    }

                }
                

                return task;

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
                return await _taskRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<TaskComments>> GetAllComments()
        {
            try
            {
                return await _commentsRepository.GetAllAsync();
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
                return await _taskRepository.GetByIdAsync(id);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
