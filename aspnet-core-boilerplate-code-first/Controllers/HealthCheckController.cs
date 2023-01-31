using aspnet_core_boilerplate_code_first.EfConfigurations.Context;
using aspnet_core_boilerplate_code_first.Middlewares.TransactionsHandling;
using Microsoft.AspNetCore.Mvc;
using static aspnet_core_boilerplate_code_first.EfConfigurations.EntityTypeConfigurations.HealthCheckEntityTypeConfiguration;

namespace aspnet_core_boilerplate_code_first.Controllers;

[ApiController]
[Route("/health-check")]
public class HealthCheckController : ControllerBase
{
    private readonly DefaultDbContext _dbContext;

    public HealthCheckController(DefaultDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    [Transactional]
    public  IActionResult Get()
    {
        var efStartup = _dbContext.EfStartup.Add(new EfStartup
        {
            status = "test"
        });
        
        
        return Ok(efStartup);
    }
    
    
}
