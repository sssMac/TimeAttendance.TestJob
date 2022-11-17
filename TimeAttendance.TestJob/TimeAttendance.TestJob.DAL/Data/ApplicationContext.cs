using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeAttendance.TestJob.DAL.Models.Entities;

namespace TimeAttendance.TestJob.DAL.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }


        public DbSet<Project> Projects { get; set; }
        public DbSet<SmallTask> SmallTasks { get; set; }
        public DbSet<TaskComments> TasksComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var projects = new List<Project>
            {
                new Project
                {
                    Id = Guid.NewGuid(),
                    ProjectName = "project-1",
                    UpdateDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                },
                new Project
                {
                    Id = Guid.NewGuid(),
                    ProjectName = "project-2",
                    UpdateDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                },
                new Project
                {
                    Id = Guid.NewGuid(),
                    ProjectName = "project-3",
                    UpdateDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                }
            };
            var tasks = new List<SmallTask>
            {
                new SmallTask
            {
                Id = Guid.NewGuid(),
                TaskName = "task-1",
                ProjectId = projects[0].Id,
                StartDate = DateTime.Now,
                CancelDate = DateTime.Now,
                CreateDate = DateTime.Now,
                DeleteDate = default
            },
            new SmallTask
            {
                Id = Guid.NewGuid(),
                TaskName = "task-2",
                ProjectId = projects[0].Id,
                StartDate = DateTime.Now,
                CancelDate = DateTime.Now,
                CreateDate = DateTime.Now,
                DeleteDate = default
            },
            new SmallTask
            {
                Id = Guid.NewGuid(),
                TaskName = "task-3",
                ProjectId = projects[0].Id,
                StartDate = DateTime.Now,
                CancelDate = DateTime.Now,
                CreateDate = DateTime.Now,
                DeleteDate = default
            },
            new SmallTask
            {
                Id = Guid.NewGuid(),
                TaskName = "task-14234",
                ProjectId = projects[1].Id,
                StartDate = DateTime.Now,
                CancelDate = DateTime.Now,
                CreateDate = DateTime.Now,
                DeleteDate = default
            },
            new SmallTask
            {
                Id = Guid.NewGuid(),
                TaskName = "task-14234",
                ProjectId = projects[1].Id,
                StartDate = DateTime.Now,
                CancelDate = DateTime.Now,
                CreateDate = DateTime.Now,
                DeleteDate = default
            },
            new SmallTask
            {
                Id = Guid.NewGuid(),
                TaskName = "task-777",
                ProjectId = projects[2].Id,
                StartDate = DateTime.Now,
                CancelDate = DateTime.Now,
                CreateDate = DateTime.Now,
                DeleteDate = default
            }
            };
            var comments = new List<TaskComments>
            {
                new TaskComments
            {
                Id = Guid.NewGuid(),
                TaskId = tasks[0].Id,
                CommentType = 0,
                Content = Encoding.ASCII.GetBytes("hello task321"),
            },
            new TaskComments
            {
                Id = Guid.NewGuid(),
                TaskId = tasks[0].Id,
                CommentType = 0,
                Content = Encoding.ASCII.GetBytes("hello world"),
            },
            new TaskComments
            {
                Id = Guid.NewGuid(),
                TaskId = tasks[1].Id,
                CommentType = 1,
                Content = Encoding.ASCII.GetBytes("hello project"),
            },
            new TaskComments
            {
                Id = Guid.NewGuid(),
                TaskId = tasks[4].Id,
                CommentType = 22,
                Content = Encoding.ASCII.GetBytes("hello task3231231"),
            }
            };



            builder.Entity<Project>().HasData(projects);
            builder.Entity<SmallTask>().HasData(tasks);
            builder.Entity<TaskComments>().HasData(comments);


        }
    }
}
