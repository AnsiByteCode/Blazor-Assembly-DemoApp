using Microsoft.EntityFrameworkCore.Migrations;

namespace CashDeskDemoApp.Server.Data.Migrations
{
    public partial class DashboardLogHistoryAddIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "DashboardLogHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IP",
                table: "DashboardLogHistory");
        }
    }
}
