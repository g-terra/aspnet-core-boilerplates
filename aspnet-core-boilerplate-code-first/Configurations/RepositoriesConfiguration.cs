using aspnet_core_boilerplate_code_first.EfConfigurations.Context;
using aspnet_core_boilerplate_code_first.Repositories;
using static aspnet_core_boilerplate_code_first.EfConfigurations.EntityTypeConfigurations.HealthCheckEntityTypeConfiguration;

namespace aspnet_core_boilerplate_code_first.Configurations;

public static class RepositoriesConfiguration
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<GenericRepository<EfStartup,DefaultDbContext>>();
    }
}