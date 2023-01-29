using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aspnet_core_boilerplate_code_first.EfConfigurations.EntityTypeConfigurations;

public class HealthCheckEntityTypeConfiguration : IEntityTypeConfiguration<HealthCheckEntityTypeConfiguration.EfStartup>
{
    public void Configure(EntityTypeBuilder<EfStartup> builder)
    {
        builder.HasKey(h => h.id);
        builder.Property(h => h.id).ValueGeneratedOnAdd();
        builder.Property(h => h.status).IsRequired();
        builder.HasData(new EfStartup
        {
            id = 1,
            status = "ok"
        });
    }
    
    public class EfStartup
    {
        public int id { get; set; }
        
        public string status { get; set; }
    }
}