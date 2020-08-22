using Microsoft.EntityFrameworkCore.Migrations;

namespace MileageTracker.Migrations
{
    public partial class UserGUIDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserGUID",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserGUID",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserGUID",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserGUID",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGUID",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "UserGUID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserGUID",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "UserGUID",
                table: "Clients");
        }
    }
}
