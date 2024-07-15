
using CustomerApp.API.Common;
using System.Text.Json;

namespace CustomerApp.API.Middlewares
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong!!!. Error : {e.Message}");
                await PrepareErrorResponseAsync(context, e);
            }
        }

        public async Task PrepareErrorResponseAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            var response = JsonSerializer.Serialize(APIResponse<string>.Error(e.Message, StatusCodes.Status500InternalServerError), StaticDeclaration.camelCase);
            await context.Response.WriteAsync(response);
        }
    }
}
