using aspnet_core_boilerplate_code_first.EfConfigurations.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace aspnet_core_boilerplate_code_first.EfConfigurations.Context;

public class MainDataBaseContext : DbContext
{

    public MainDataBaseContext( DbContextOptions<MainDataBaseContext> options) : base(options)
    {
        
    }

    public DbSet<HealthCheckEntityTypeConfiguration.EfStartup> EfStartup { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HealthCheckEntityTypeConfiguration());
    }
}