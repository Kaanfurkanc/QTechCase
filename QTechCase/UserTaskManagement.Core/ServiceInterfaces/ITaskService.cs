using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Core.DTOs;
using UserTaskManagement.Core.DTOs.Task;

namespace UserTaskManagement.Core.ServiceInterfaces
{
    public interface ITaskService
    {
        Task CreateTaskAsync(TaskCreateDTO taskCreateDTO);
        Task<IEnumerable<TaskReadDTO>> GetAllTasksAsync();
        Task<IEnumerable<TaskReadDTO>> GetTasksByUserIdAsync(int userId);
        Task CompleteTaskAsync(int taskId);
    }
}
