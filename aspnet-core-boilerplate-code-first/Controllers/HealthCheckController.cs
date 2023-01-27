using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace aspnet_core_boilerplate_code_first.Controllers;

[ApiController]
[Route("/health-check")]
public class HealthCheckController : ControllerBase
{
    private readonly ILogger<HealthCheckController> _logger;
    private readonly HealthCheckService _service;

    public HealthCheckController(ILogger<HealthCheckController> logger, HealthCheckService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var report = await _service.CheckHealthAsync();

        _logger.LogInformation($"Get Health Information: {report}");

        return report.Status == HealthStatus.Healthy ? Ok(report) : StatusCode((int)HttpStatusCode.ServiceUnavailable, report);
    }
}