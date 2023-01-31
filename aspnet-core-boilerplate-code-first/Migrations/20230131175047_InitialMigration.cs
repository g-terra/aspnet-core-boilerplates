using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnet_core_boilerplate_code_first.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EfStartup",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EfStartup", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "EfStartup",
                columns: new[] { "id", "status" },
                values: new object[] { 1, "ok" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EfStartup");
        }
    }
}
