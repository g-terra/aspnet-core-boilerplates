using aspnet_core_boilerplate_code_first.EfConfigurations.Context;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace aspnet_core_boilerplate_code_first.Middlewares.TransactionsHandling;

public class TransactionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<TransactionHandlerMiddleware> _logger;

    public TransactionHandlerMiddleware(RequestDelegate next, ILogger<TransactionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext, DefaultDbContext dbContext)
    {
        if (IsTransactionalContext(httpContext))
        {
            await HandleTransaction(httpContext, dbContext);
        }
        else
        {
            await _next(httpContext);
        }
    }

    private static bool IsTransactionalContext(HttpContext httpContext)
    {
        var endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
        return endpoint?.Metadata.GetMetadata<TransactionalAttribute>() != null;
    }

    private async Task HandleTransaction(HttpContext httpContext, DbContext dbContext)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();
        _logger.LogInformation("transaction started");

        try
        {
            await _next(httpContext);
            await CommitIf2XXStatus(httpContext, transaction);
        }
        catch (Exception)
        {
            await RollBack(transaction);
            throw;
        }
    }

    private async Task CommitIf2XXStatus(HttpContext httpContext, IDbContextTransaction transaction)
    {
        await transaction.CreateSavepointAsync("start");


        if (httpContext.Response.StatusCode is >= 200 and < 300)
        {
            await Commit(transaction);
        }
        else
        {
            await RollBack(transaction);
        }
    }

    private async Task Commit(IDbContextTransaction transaction)
    {
        await transaction.CommitAsync();
        _logger.LogInformation("transaction committed");
    }

    private async Task RollBack(IDbContextTransaction transaction)
    {
        await transaction.RollbackToSavepointAsync("start");
        _logger.LogInformation("transaction rolled back");
    }
}