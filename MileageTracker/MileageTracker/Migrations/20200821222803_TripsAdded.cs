using Microsoft.EntityFrameworkCore.Migrations;

namespace MileageTracker.Migrations
{
    public partial class TripsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Expenses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "BeginMileage",
                table: "Expenses",
                type: "decimal(18, 1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EndMileage",
                table: "Expenses",
                type: "decimal(18, 1)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "Expenses",
                type: "decimal(18, 2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeeDescription",
                table: "Expenses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleID",
                table: "Expenses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_VehicleID",
                table: "Expenses",
                column: "VehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Vehicle_VehicleID",
                table: "Expenses",
                column: "VehicleID",
                principalTable: "Vehicle",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Vehicle_VehicleID",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_VehicleID",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "BeginMileage",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "EndMileage",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "FeeDescription",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "VehicleID",
                table: "Expenses");
        }
    }
}
