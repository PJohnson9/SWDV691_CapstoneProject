using Microsoft.EntityFrameworkCore.Migrations;

namespace MileageTracker.Migrations
{
    public partial class EntityRelationshipsStarted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Project",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Expense",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientID",
                table: "Project",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ProjectID",
                table: "Expense",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Project_ProjectID",
                table: "Expense",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientID",
                table: "Project",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Project_ProjectID",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientID",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientID",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Expense_ProjectID",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Expense",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }
    }
}
