using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update76 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeductPoint",
                table: "UnsafeItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeductPoints",
                columns: table => new
                {
                    DeductPointId = table.Column<int>(nullable: false),
                    DeductCode = table.Column<string>(maxLength: 2, nullable: true),
                    Warning = table.Column<string>(maxLength: 150, nullable: true),
                    Point = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductPoints", x => x.DeductPointId);
                });

            migrationBuilder.CreateTable(
                name: "LogBranchAccidents",
                columns: table => new
                {
                    BranchCode = table.Column<string>(maxLength: 15, nullable: false),
                    MaxNumber = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogBranchAccidents", x => x.BranchCode);
                });

            migrationBuilder.CreateTable(
                name: "logEmployeeAccidents",
                columns: table => new
                {
                    EmployeeCode = table.Column<string>(maxLength: 11, nullable: false),
                    MaxNumber = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logEmployeeAccidents", x => x.EmployeeCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeductPoints");

            migrationBuilder.DropTable(
                name: "LogBranchAccidents");

            migrationBuilder.DropTable(
                name: "logEmployeeAccidents");

            migrationBuilder.DropColumn(
                name: "DeductPoint",
                table: "UnsafeItems");
        }
    }
}
