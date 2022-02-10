using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogNumbers",
                columns: table => new
                {
                    Prefix = table.Column<string>(maxLength: 6, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    MaxNumber = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogNumbers", x => x.Prefix);
                });
        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogNumbers");
        }
    }
}
