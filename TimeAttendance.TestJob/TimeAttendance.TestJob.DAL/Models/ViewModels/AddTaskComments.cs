using Microsoft.AspNetCore.Http;

namespace TimeAttendance.TestJob.DAL.Models.ViewModels
{
    public class AddTaskComments
    {
        public Guid TaskId { get; set; }
        public string? CommentType { get; set; }
        public string? StringContent { get; set; }
        public IFormFile? FileContent { get; set; }
    }
}

