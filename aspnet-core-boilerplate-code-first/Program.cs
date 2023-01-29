using aspnet_core_boilerplate_code_first.Configurations;
using aspnet_core_boilerplate_code_first.Helpers;
using aspnet_core_boilerplate_code_first.Middlewares.ExceptionHandling;
using aspnet_core_boilerplate_code_first.Middlewares.TransactionsHandling;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterContext(builder.Configuration);

builder.Services.RegisterHealthCheck(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UsePathBase("/api");

app.UseHttpsRedirection();

app.UseRouting();

app.UseTransactionHandler();

app.UseGlobalErrorHandler();

app.MapControllers();

app.Run();

