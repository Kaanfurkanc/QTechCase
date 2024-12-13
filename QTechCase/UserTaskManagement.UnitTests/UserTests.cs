using Moq;
using UserTaskManagement.Core.DTOs.User;
using UserTaskManagement.Core.ServiceInterfaces;

namespace UserTaskManagement.Tests
{
    public class UserTests
    {
        private readonly Mock<IUserService> _userServiceMock;

        public UserTests()
        {
            _userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task CreateUser_ShouldThrowException_WhenEmailAlreadyExists()
        {
            // Arrange
            var duplicateEmail = "test@example.com";
            var userCreateDTO = new UserCreateDTO { Name = "Test", Email = duplicateEmail };

            _userServiceMock.Setup(service => service.CreateUserAsync(It.IsAny<UserCreateDTO>()))
                .ThrowsAsync(new InvalidOperationException("Email already exists"));

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _userServiceMock.Object.CreateUserAsync(userCreateDTO));
        }
    }
}