using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserTaskManagement.Core.DTOs.Task;
using UserTaskManagement.Core.ServiceInterfaces;

namespace UserTaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(ITaskService taskService) : ControllerBase
    {
        private readonly ITaskService _taskService = taskService;

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateDTO taskCreateDTO)
        {
            await _taskService.CreateTaskAsync(taskCreateDTO);
            return Created("", null);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTasksByUserId(int userId)
        {
            var tasks = await _taskService.GetTasksByUserIdAsync(userId);
            return Ok(tasks);
        }

        [HttpPut("{taskId}/complete")]
        public async Task<IActionResult> MarkTaskAsCompleted(int taskId)
        {
            await _taskService.CompleteTaskAsync(taskId);
            return NoContent();
        }
    }
}
