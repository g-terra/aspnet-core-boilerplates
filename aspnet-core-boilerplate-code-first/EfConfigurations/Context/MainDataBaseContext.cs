using aspnet_core_boilerplate_code_first.EfConfigurations.EntityTypeConfigurations;
using aspnet_core_boilerplate_code_first.Helpers;
using Microsoft.EntityFrameworkCore;

namespace aspnet_core_boilerplate_code_first.EfConfigurations.Context;

public class MainDataBaseContext : DbContext
{

    private readonly IConfiguration _configuration;

    protected MainDataBaseContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public MainDataBaseContext(IConfiguration configuration, DbContextOptions options) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<HealthCheckEntityTypeConfiguration.EfStartup> EfStartup { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        optionsBuilder.UseSqlServer(_configuration.GetConnectionString(MainDatabaseConfigurationKey.Get()));
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HealthCheckEntityTypeConfiguration());
    }
}