using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeAttendance.TestJob.DAL.Models;

namespace TimeAttendance.TestJob.DAL.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<SmallTask> SmallTasks { get; set; }
        public DbSet<TaskComments> TasksComments { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }
    }
}
