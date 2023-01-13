using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelManager.Migrations
{
    public partial class addfueltype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuelType",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Cars");
        }
    }
}
