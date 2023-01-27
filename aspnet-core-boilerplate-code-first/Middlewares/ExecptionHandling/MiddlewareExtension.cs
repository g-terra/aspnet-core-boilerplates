namespace aspnet_core_boilerplate_code_first.Middlewares.ExecptionHandling;

public static class MiddlewareExtension
{
    public static void UseGlobalErrorHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}