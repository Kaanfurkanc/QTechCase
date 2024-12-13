using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserTaskManagement.Core.DTOs.Task;
using UserTaskManagement.Core.Entities;
using UserTaskManagement.Core.GenericRepository;
using UserTaskManagement.Core.ServiceInterfaces;
using Task = UserTaskManagement.Core.Entities.Task;
using TaskStatus = UserTaskManagement.Core.Entities.TaskStatus;

namespace UserTaskManagement.Service
{
    public class TaskService(IGenericRepository<User> userRepository, IGenericRepository<Task> taskRepository, IMapper mapper) : ITaskService
    {
        private readonly IGenericRepository<User> _userRepository = userRepository;
        private readonly IGenericRepository<Task> _taskRepository = taskRepository;
        private readonly IMapper _mapper = mapper;
        public async System.Threading.Tasks.Task CompleteTaskAsync(int taskId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            if (task == null)
                throw new InvalidOperationException("Task does not exist.");

            task.Status = TaskStatus.Completed;
            _taskRepository.Update(task);
        }

        public async System.Threading.Tasks.Task CreateTaskAsync(TaskCreateDTO taskCreateDTO)
        {
            var user = await _userRepository.GetByIdAsync(taskCreateDTO.UserId);
            if (user == null)
                throw new InvalidOperationException("Assigned user does not exist.");

            var task = _mapper.Map<Task>(taskCreateDTO);
            await _taskRepository.AddAsync(task);
        }

        public async Task<IEnumerable<TaskReadDTO>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskReadDTO>>(tasks);
        }

        public async Task<IEnumerable<TaskReadDTO>> GetTasksByUserIdAsync(int userId)
        {
            var tasks = await _taskRepository.Where(t => t.UserId == userId).ToListAsync();
            return _mapper.Map<IEnumerable<TaskReadDTO>>(tasks);
        }
    }
}
