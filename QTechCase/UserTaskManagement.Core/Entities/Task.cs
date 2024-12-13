using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskManagement.Core.Entities
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.ToDo;
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Review,
        Completed
    }
}
