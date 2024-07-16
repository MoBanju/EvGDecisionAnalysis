using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvGDecisionAnalysis.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NPVResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NPVE1 = table.Column<double>(type: "REAL", nullable: false),
                    PE1 = table.Column<double>(type: "REAL", nullable: false),
                    NPVE2 = table.Column<double>(type: "REAL", nullable: false),
                    PE2 = table.Column<double>(type: "REAL", nullable: false),
                    CalculatedNPV = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPVResults", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NPVResults");
        }
    }
}
