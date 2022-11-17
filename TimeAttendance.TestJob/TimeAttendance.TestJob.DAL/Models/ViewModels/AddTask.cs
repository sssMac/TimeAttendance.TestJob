using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAttendance.TestJob.DAL.Models.ViewModels
{
    public class AddTask
    {
        public string TaskName { get; set; }
        public string ProjectId { get; set; }
        public string StartDate { get; set; }
        public string CancelDate { get; set; }
        public string? CommentType { get; set; }
        public string? StringContent { get; set; }
        public IFormFile? FileContent { get; set; }
    }
}
