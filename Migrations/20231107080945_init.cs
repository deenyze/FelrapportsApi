using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FelrapportsApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Felrapport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecreatingSteps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedBehavior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualBehavior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    Logs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Felrapport", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Felrapport");
        }
    }
}
