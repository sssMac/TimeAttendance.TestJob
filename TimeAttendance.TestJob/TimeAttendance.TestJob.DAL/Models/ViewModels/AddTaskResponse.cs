using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAttendance.TestJob.DAL.Models.Entities;

namespace TimeAttendance.TestJob.DAL.Models.ViewModels
{
    public class AddTaskResponse
    {
        public SmallTask task { get; set; }
        public TaskComments comme { get; set; }
    }
}
