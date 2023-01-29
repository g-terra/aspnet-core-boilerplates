using System.Net;
using System.Security.Authentication;
using aspnet_core_boilerplate_code_first.Exceptions;
using Newtonsoft.Json;

namespace aspnet_core_boilerplate_code_first.Middlewares.ExceptionHandling;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            _logger.LogWarning("Warning : {m}", ex.Message);
            await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: {m}", ex.Message);
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
        }
    }

    private static Task HandleExceptionAsync(
        HttpContext context,
        Exception ex,
        HttpStatusCode code
    )
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = code,
            Message = ex.Message,
            StackTrace = ex.StackTrace
        }.ToString());
    }

    public class ErrorDetails
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }

        public string? StackTrace { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}