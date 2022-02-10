using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastMaintenanceDate",
                table: "PartTwos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastMaintenanceOdometer",
                table: "PartTwos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMaintenanceDate",
                table: "PartTwos");

            migrationBuilder.DropColumn(
                name: "LastMaintenanceOdometer",
                table: "PartTwos");
        }
    }
}
