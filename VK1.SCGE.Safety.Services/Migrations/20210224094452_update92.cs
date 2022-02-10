using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update92 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_Employees_EmployeeCode",
                table: "PartOnes");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "PartOnes");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "PartOnes",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeCode",
                table: "PartOnes",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "PartOnes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PositionName",
                table: "PartOnes",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartOnes_PositionId",
                table: "PartOnes",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_Positions_PositionId",
                table: "PartOnes",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_Positions_PositionId",
                table: "PartOnes");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_PartOnes_PositionId",
                table: "PartOnes");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "PartOnes");

            migrationBuilder.DropColumn(
                name: "PositionName",
                table: "PartOnes");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeName",
                table: "PartOnes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeCode",
                table: "PartOnes",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "PartOnes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_Employees_EmployeeCode",
                table: "PartOnes",
                column: "EmployeeCode",
                principalTable: "Employees",
                principalColumn: "EmployeeCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
