namespace UserTaskManagement.API.Middlewares.Extensions
{
    public static class Extensions
    {
        public static IApplicationBuilder UseUnitOfWork(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UnitOfWorkMiddleware>();
        }

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
