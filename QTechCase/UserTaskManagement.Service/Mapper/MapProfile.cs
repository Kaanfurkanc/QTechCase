using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Core.DTOs.User;
using UserTaskManagement.Core.DTOs.Task;
using UserTaskManagement.Core.Entities;

namespace UserTaskManagement.Service.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserReadDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();

            CreateMap<UserTaskManagement.Core.Entities.Task, TaskReadDTO>().ReverseMap();
            CreateMap<UserTaskManagement.Core.Entities.Task, TaskCreateDTO>().ReverseMap();
            CreateMap<UserTaskManagement.Core.Entities.Task, TaskUpdateDTO>().ReverseMap();
        }
    }
}
