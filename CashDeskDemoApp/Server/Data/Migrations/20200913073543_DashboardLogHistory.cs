using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashDeskDemoApp.Server.Data.Migrations
{
    public partial class DashboardLogHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DashboardLogHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContinentName = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardLogHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardLogHistory_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DashboardLogHistory_AppUserId",
                table: "DashboardLogHistory",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashboardLogHistory");
        }
    }
}
