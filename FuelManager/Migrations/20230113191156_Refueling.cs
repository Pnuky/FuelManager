using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelManager.Migrations
{
    public partial class Refueling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consumption",
                table: "Cars");

            migrationBuilder.CreateTable(
                name: "Refueling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Run = table.Column<int>(type: "int", nullable: false),
                    RefuelingAmount = table.Column<double>(type: "float", nullable: false),
                    Compsumption = table.Column<double>(type: "float", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refueling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refueling_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Refueling_CarId",
                table: "Refueling",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Refueling");

            migrationBuilder.AddColumn<double>(
                name: "Consumption",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
