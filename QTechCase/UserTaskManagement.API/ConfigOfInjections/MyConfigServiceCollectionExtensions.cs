using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using UserTaskManagement.Core.GenericRepository;
using UserTaskManagement.Core.ServiceInterfaces;
using UserTaskManagement.Core.UnitOfWork;
using UserTaskManagement.Repository;
using UserTaskManagement.Repository.GenericRepository;
using UserTaskManagement.Repository.UnitOfWork;
using UserTaskManagement.Service;
using UserTaskManagement.Service.Mapper;

namespace UserTaskManagement.API.ConfigOfInjections
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDependencyGroup(
                            this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => 
                options.UseInMemoryDatabase("InMemoryDb"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();

            services.AddAutoMapper(typeof(MapProfile));

            return services;
        }
    }
}
