using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserTaskManagement.Core.DTOs.User;
using UserTaskManagement.Core.ServiceInterfaces;

namespace UserTaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO userCreateDTO)
        {
            await _userService.CreateUserAsync(userCreateDTO);
            return Created("", null);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
