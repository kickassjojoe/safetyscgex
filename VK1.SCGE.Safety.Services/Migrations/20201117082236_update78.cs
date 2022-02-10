using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update78 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogBranchAccidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_logEmployeeAccidents",
                table: "logEmployeeAccidents");

            migrationBuilder.RenameTable(
                name: "logEmployeeAccidents",
                newName: "LogEmployeeAccidents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogEmployeeAccidents",
                table: "LogEmployeeAccidents",
                column: "EmployeeCode");

            migrationBuilder.CreateTable(
                name: "PenaltyNotices",
                columns: table => new
                {
                    PenaltyNoticeCode = table.Column<string>(maxLength: 11, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    EmployeeCode = table.Column<string>(maxLength: 11, nullable: true),
                    EmployeeName = table.Column<string>(maxLength: 150, nullable: true),
                    BranchCode = table.Column<string>(maxLength: 15, nullable: true),
                    BranchName = table.Column<string>(maxLength: 150, nullable: true),
                    IncidentDescription = table.Column<string>(maxLength: 200, nullable: true),
                    CaseDate = table.Column<DateTime>(nullable: false),
                    CaseCount = table.Column<string>(maxLength: 15, nullable: true),
                    DeductDescription = table.Column<string>(maxLength: 250, nullable: true),
                    TruckDamageDescription = table.Column<string>(maxLength: 250, nullable: true),
                    Warning = table.Column<string>(maxLength: 250, nullable: true),
                    DeductPointAccident = table.Column<int>(nullable: false),
                    DeductMoneyAccident = table.Column<decimal>(nullable: false),
                    DeductPointUnsafe = table.Column<int>(nullable: false),
                    DeductMoneyUnsafe = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenaltyNotices", x => x.PenaltyNoticeCode);
                });

            migrationBuilder.CreateTable(
                name: "PenaltyNoticeDetails",
                columns: table => new
                {
                    PenaltyNoticeDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    PenaltyNoticeCode = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenaltyNoticeDetails", x => x.PenaltyNoticeDetailId);
                    table.ForeignKey(
                        name: "FK_PenaltyNoticeDetails_PenaltyNotices_PenaltyNoticeCode",
                        column: x => x.PenaltyNoticeCode,
                        principalTable: "PenaltyNotices",
                        principalColumn: "PenaltyNoticeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PenaltyNoticeDetails_PenaltyNoticeCode",
                table: "PenaltyNoticeDetails",
                column: "PenaltyNoticeCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PenaltyNoticeDetails");

            migrationBuilder.DropTable(
                name: "PenaltyNotices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogEmployeeAccidents",
                table: "LogEmployeeAccidents");

            migrationBuilder.RenameTable(
                name: "LogEmployeeAccidents",
                newName: "logEmployeeAccidents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_logEmployeeAccidents",
                table: "logEmployeeAccidents",
                column: "EmployeeCode");

            migrationBuilder.CreateTable(
                name: "LogBranchAccidents",
                columns: table => new
                {
                    BranchCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MaxNumber = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogBranchAccidents", x => x.BranchCode);
                });
        }
    }
}
