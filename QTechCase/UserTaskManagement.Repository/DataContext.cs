using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Core.Entities;
using Task = UserTaskManagement.Core.Entities.Task;
using TaskStatus = UserTaskManagement.Core.Entities.TaskStatus;

namespace UserTaskManagement.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Task>().HasKey(t => t.Id);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Kaan", Surname = "Çakıroğlu", Email = "kaan@example.com", Password = "12345", Role = "Admin", CreatedDate = DateTime.UtcNow },
                new User { Id = 2, Name = "Furkan", Surname = "Çakıroğlu", Email = "furkan.34@example.com", Password = "123456", Role = "User", CreatedDate = DateTime.UtcNow }
            );

            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 1, Title = "Complete Project", Description = "Finish the N-Tier Architecture project", DueDate = DateTime.UtcNow.AddDays(7), Status = TaskStatus.InProgress, UserId = 1, CreatedDate = DateTime.UtcNow },
                new Task { Id = 2, Title = "Prepare Report", Description = "Prepare the final project report", DueDate = DateTime.UtcNow.AddDays(10), Status = TaskStatus.ToDo, UserId = 2, CreatedDate = DateTime.UtcNow }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
