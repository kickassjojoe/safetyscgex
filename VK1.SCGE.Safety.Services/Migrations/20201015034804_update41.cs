using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "CaseTime",
                table: "PartOnes",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseTime",
                table: "PartOnes");
        }
    }
}
