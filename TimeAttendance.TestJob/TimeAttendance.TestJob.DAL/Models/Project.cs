using System.ComponentModel.DataAnnotations;
using TimeAttendance.TestJob.DAL.Interfaces;

namespace TimeAttendance.TestJob.DAL.Models
{
    public class Project : IDBModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? ProjectName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
