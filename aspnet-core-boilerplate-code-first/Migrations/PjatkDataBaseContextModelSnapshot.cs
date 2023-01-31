﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnet_core_boilerplate_code_first.EfConfigurations.Context;

#nullable disable

namespace aspnet_core_boilerplate_code_first.Migrations
{
    [DbContext(typeof(PjatkDataBaseContext))]
    partial class PjatkDataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("aspnet_core_boilerplate_code_first.EfConfigurations.EntityTypeConfigurations.HealthCheckEntityTypeConfiguration+EfStartup", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("EfStartup");

                    b.HasData(
                        new
                        {
                            id = 1,
                            status = "ok"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}