using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Core.DTOs.User;

namespace UserTaskManagement.Core.ServiceInterfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(UserCreateDTO userCreateDTO);
        Task<IEnumerable<UserReadDTO>> GetAllUsersAsync();
        Task<UserReadDTO> GetUserByIdAsync(int id);
        Task UpdateUserAsync(int id, UserUpdateDTO userUpdateDTO);
        Task DeleteUserAsync(int id);
    }
}
