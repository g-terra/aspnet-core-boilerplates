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
    private readonly GenericRepository<EfStartup, DefaultDbContext> _repository;

    public HealthCheckController(GenericRepository<EfStartup, DefaultDbContext> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Transactional]
    public  IActionResult Get()
    {
        var efStartup = _repository.Insert(new EfStartup
        {
            status = "test"
        });
        
        
        return Ok(efStartup);
    }
    
    
}
