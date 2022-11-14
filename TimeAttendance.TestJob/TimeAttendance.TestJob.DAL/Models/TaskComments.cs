using TimeAttendance.TestJob.DAL.Interfaces;

namespace TimeAttendance.TestJob.DAL.Models
{
    public class TaskComments : IDBModel
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public byte CommentType { get; set; }
        public byte[] Content { get; set; }
    }
}
