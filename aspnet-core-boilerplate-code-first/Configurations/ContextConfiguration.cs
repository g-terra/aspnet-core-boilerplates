using aspnet_core_boilerplate_code_first.EfConfigurations.Context;
using aspnet_core_boilerplate_code_first.Helpers;
using Microsoft.EntityFrameworkCore;

namespace aspnet_core_boilerplate_code_first.Configurations;

public static class ContextConfiguration
{
    public static void RegisterContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MainDataBaseContext>(builder =>
        {
            builder.UseSqlServer(configuration.GetDefaultConnection());
        });
    }
}