using System.Net;
using aspnet_core_boilerplate_code_first.EfConfigurations.Context;
using aspnet_core_boilerplate_code_first.Middlewares.TransactionsHandling;
using aspnet_core_boilerplate_code_first.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using static aspnet_core_boilerplate_code_first.EfConfigurations.EntityTypeConfigurations.HealthCheckEntityTypeConfiguration;

namespace aspnet_core_boilerplate_code_first.Controllers;

[ApiController]
[Route("/health-check")]
public class HealthCheckController : ControllerBase
{
    private readonly ILogger<HealthCheckController> _logger;
    private readonly HealthCheckService _service;
    private readonly GenericRepository<EfStartup, PjatkDataBaseContext> _repository;

    public HealthCheckController(ILogger<HealthCheckController> logger, HealthCheckService service, GenericRepository<EfStartup, PjatkDataBaseContext> repository)
    {
        _logger = logger;
        _service = service;
        _repository = repository;
    }

    [HttpGet]
    [Transactional]
    public  IActionResult Get()
    {
        return Ok( _repository.Insert(new EfStartup
        {
            status = "test"
        }));
    }
    
    
}
