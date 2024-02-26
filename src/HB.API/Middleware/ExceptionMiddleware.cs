using HB.API.Shared;
using HB.Domain.Shared;
using System.Text.Json;

namespace HB.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var error = _env.IsProduction() ? new Error("500", ex.Message, string.Empty) :
                new Error("500", ex.Message, ex.StackTrace);

            var apiResponse = new ApiResponse(error);

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string response = JsonSerializer.Serialize(apiResponse, jsonOptions);

            await context.Response.WriteAsync(response);
        }
    }
}
