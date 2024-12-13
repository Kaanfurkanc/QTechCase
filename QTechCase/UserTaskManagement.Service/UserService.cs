using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserTaskManagement.Core.DTOs.User;
using UserTaskManagement.Core.Entities;
using UserTaskManagement.Core.GenericRepository;
using UserTaskManagement.Core.ServiceInterfaces;

namespace UserTaskManagement.Service
{
    public class UserService(IGenericRepository<User> genericRepository, IMapper mapper) : IUserService
    {
        private readonly IGenericRepository<User> _genericRepository = genericRepository;
        private readonly IMapper _mapper = mapper;
        public async System.Threading.Tasks.Task CreateUserAsync(UserCreateDTO userCreateDTO)
        {
            var existingUser = await _genericRepository.Where(u => u.Email == userCreateDTO.Email).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                throw new InvalidOperationException("Email already exists");
            }

            var user = _mapper.Map<User>(userCreateDTO);
            await _genericRepository.AddAsync(user);
        }

        public async System.Threading.Tasks.Task DeleteUserAsync(int id)
        {
            var user = await _genericRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _genericRepository.Delete(user);
        }

        public async Task<IEnumerable<UserReadDTO>> GetAllUsersAsync()
        {
            var users = await _genericRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserReadDTO>>(users);
        }

        public async Task<UserReadDTO> GetUserByIdAsync(int id)
        {
            var user = await _genericRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return _mapper.Map<UserReadDTO>(user);
        }

        public async System.Threading.Tasks.Task UpdateUserAsync(int id, UserUpdateDTO userUpdateDTO)
        {
            var user = await _genericRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _mapper.Map(userUpdateDTO, user);
            _genericRepository.Update(user);
        }
    }
}
