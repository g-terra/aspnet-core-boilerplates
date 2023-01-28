namespace aspnet_core_boilerplate_code_first.Middlewares.TransactionsHandling;

public static class MiddlewareExtension
{
    public static void UseTransactionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<TransactionHandlerMiddleware>();
    }
}