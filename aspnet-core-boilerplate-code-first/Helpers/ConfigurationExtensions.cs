namespace aspnet_core_boilerplate_code_first.Helpers;

public static class ConfigurationExtensions
{
    public static string GetDefaultConnection(this IConfiguration configuration)
    {
        return configuration.GetConnectionString("PjatkConnection");
    } 
    
   
}