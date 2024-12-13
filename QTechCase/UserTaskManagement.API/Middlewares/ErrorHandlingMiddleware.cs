using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace UserTaskManagement.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Opps .. Something went wrong : {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var exceptionType = exception.GetType().ToString();

            switch (exceptionType)
            {
                case nameof(ValidationException):
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsync(context.Response.StatusCode + $"Bad Request ! : {exception.Message}");
                    break;
                case nameof(NotFoundResult):
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await context.Response.WriteAsync(context.Response.StatusCode + $"Not Found ! : {exception.Message}");
                    break;
                case nameof(UnauthorizedAccessException):
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsync(context.Response.StatusCode + $" Unauthorized: {exception.Message}");
                    break;
                case nameof(ForbiddenException):
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    await context.Response.WriteAsync(context.Response.StatusCode + $" Forbidden: {exception.Message}");
                    break;
                case nameof(MethodNotAllowedException):
                    context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                    await context.Response.WriteAsync(context.Response.StatusCode + $" Method Not Allowed: {exception.Message}");
                    break;
                case nameof(NotImplementedException):
                    context.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
                    await context.Response.WriteAsync(context.Response.StatusCode + $" Not Implemented: {exception.Message}");
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync(context.Response.StatusCode + $"Internal Server Error ! : {exception.Message}");
                    break;
            }
        }
    }
}
