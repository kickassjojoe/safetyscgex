using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "CorrectiveActionRequests",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "CorrectiveActionRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FixedBy",
                table: "CorrectiveActionRequestItems",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FixedDate",
                table: "CorrectiveActionRequestItems",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "CorrectiveActionRequests");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "CorrectiveActionRequests");

            migrationBuilder.DropColumn(
                name: "FixedBy",
                table: "CorrectiveActionRequestItems");

            migrationBuilder.DropColumn(
                name: "FixedDate",
                table: "CorrectiveActionRequestItems");
        }
    }
}
