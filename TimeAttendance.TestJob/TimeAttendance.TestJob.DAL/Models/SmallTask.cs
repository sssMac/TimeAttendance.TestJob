using System.ComponentModel.DataAnnotations;
using TimeAttendance.TestJob.DAL.Interfaces;

namespace TimeAttendance.TestJob.DAL.Models
{
    public class SmallTask : IDBModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? TaskName { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CancelDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
