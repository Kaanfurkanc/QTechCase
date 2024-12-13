using UserTaskManagement.Core.UnitOfWork;

namespace UserTaskManagement.API.Middlewares
{
    public class UnitOfWorkMiddleware
    {
        private readonly RequestDelegate _next;
        public UnitOfWorkMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork)
        {
            await _next.Invoke(context);
            await unitOfWork.CommitAsync();
        }
    }
}
