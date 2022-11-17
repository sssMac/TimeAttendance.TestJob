using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAttendance.TestJob.DAL.Models.ViewModels
{
    public class UpdateTask
    {
        public string Id { get; set; }
        public string? TaskName { get; set; }
        public string ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CancelDate { get; set; }
        public string? CommentId { get; set; }
        public string? CommentType { get; set; }
        public string? StringContent { get; set; }
        public IFormFile? FileContent { get; set; }

    }
}
