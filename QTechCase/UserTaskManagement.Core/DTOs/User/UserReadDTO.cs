using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Core.DTOs.Task;

namespace UserTaskManagement.Core.DTOs.User
{
    public class UserReadDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<TaskReadDTO>? Tasks { get; set; }
    }
}
