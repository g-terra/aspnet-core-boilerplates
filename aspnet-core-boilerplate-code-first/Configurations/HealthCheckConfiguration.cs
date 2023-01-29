using aspnet_core_boilerplate_code_first.EfConfigurations.Context;
using aspnet_core_boilerplate_code_first.Helpers;

namespace aspnet_core_boilerplate_code_first.Configurations;

public static class HealthCheckConfiguration
{
    public static void RegisterHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks();

        services.AddHealthChecks().AddSqlServer(configuration.GetDefaultConnection());
        
        services.AddHealthChecks().AddDbContextCheck<MainDataBaseContext>();
    }
}