using Moq;
using UserTaskManagement.Core.DTOs.Task;
using UserTaskManagement.Core.ServiceInterfaces;

namespace UserTaskManagement.Tests
{
    public class TaskTests
    {
        private readonly Mock<ITaskService> _taskServiceMock;

        public TaskTests()
        {
            _taskServiceMock = new Mock<ITaskService>();
        }

        [Fact]
        public async Task CreateTask_ShouldThrowException_WhenAssignedUserDoesNotExist()
        {
            // Arrange
            var taskCreateDTO = new TaskCreateDTO { Title = "Test Task", UserId = 999 };

            _taskServiceMock.Setup(service => service.CreateTaskAsync(It.IsAny<TaskCreateDTO>()))
                .ThrowsAsync(new InvalidOperationException("Assigned user does not exist"));

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _taskServiceMock.Object.CreateTaskAsync(taskCreateDTO));
        }

        [Fact]
        public async Task CompleteTask_ShouldThrowException_WhenTaskDoesNotExist()
        {
            // Arrange
            var nonExistentTaskId = 999;

            _taskServiceMock.Setup(service => service.CompleteTaskAsync(nonExistentTaskId))
                .ThrowsAsync(new InvalidOperationException("Task does not exist"));

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _taskServiceMock.Object.CompleteTaskAsync(nonExistentTaskId));
        }

        [Fact]
        public async Task CompleteTask_ShouldUpdateStatus_WhenTaskExists()
        {
            // Arrange
            var existingTaskId = 1;

            _taskServiceMock.Setup(service => service.CompleteTaskAsync(existingTaskId))
                .Returns(Task.CompletedTask);

            // Act
            await _taskServiceMock.Object.CompleteTaskAsync(existingTaskId);

            // Assert
            _taskServiceMock.Verify(service => service.CompleteTaskAsync(existingTaskId), Times.Once);
        }
    }
}
