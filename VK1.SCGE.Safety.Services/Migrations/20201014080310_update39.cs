using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update39 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestigateCards",
                columns: table => new
                {
                    InvestigateCardId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigateCards", x => x.InvestigateCardId);
                });

            migrationBuilder.CreateTable(
                name: "PartOnes",
                columns: table => new
                {
                    PartOneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    InvestigateCardId = table.Column<Guid>(nullable: false),
                    CaseName = table.Column<string>(maxLength: 250, nullable: false),
                    BranchCode = table.Column<string>(maxLength: 15, nullable: false),
                    BranchCode1 = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(maxLength: 200, nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    RegionName = table.Column<string>(maxLength: 150, nullable: false),
                    CaseDate = table.Column<DateTime>(nullable: false),
                    CaseLocation = table.Column<string>(maxLength: 250, nullable: false),
                    EmployeeCode = table.Column<string>(maxLength: 11, nullable: false),
                    EmployeeCode1 = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(maxLength: 100, nullable: true),
                    Position = table.Column<string>(maxLength: 100, nullable: true),
                    Age = table.Column<int>(nullable: false),
                    YearExperience = table.Column<int>(nullable: false),
                    DriverExperience = table.Column<int>(nullable: false),
                    Telephone = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 150, nullable: true),
                    Shift = table.Column<string>(maxLength: 100, nullable: true),
                    CaseType = table.Column<string>(nullable: false),
                    AccidentMode = table.Column<string>(nullable: false),
                    TransportBy = table.Column<string>(nullable: false),
                    TransportLicense = table.Column<string>(maxLength: 20, nullable: true),
                    OtherBy = table.Column<string>(nullable: false),
                    Rank = table.Column<string>(nullable: false),
                    SolutionHour = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOnes", x => x.PartOneId);
                    table.ForeignKey(
                        name: "FK_PartOnes_Branches_BranchCode1",
                        column: x => x.BranchCode1,
                        principalTable: "Branches",
                        principalColumn: "BranchCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartOnes_Employees_EmployeeCode1",
                        column: x => x.EmployeeCode1,
                        principalTable: "Employees",
                        principalColumn: "EmployeeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartOnes_InvestigateCards_InvestigateCardId",
                        column: x => x.InvestigateCardId,
                        principalTable: "InvestigateCards",
                        principalColumn: "InvestigateCardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartOnes_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartOnes_BranchCode1",
                table: "PartOnes",
                column: "BranchCode1");

            migrationBuilder.CreateIndex(
                name: "IX_PartOnes_EmployeeCode1",
                table: "PartOnes",
                column: "EmployeeCode1");

            migrationBuilder.CreateIndex(
                name: "IX_PartOnes_InvestigateCardId",
                table: "PartOnes",
                column: "InvestigateCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartOnes_RegionId",
                table: "PartOnes",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartOnes");

            migrationBuilder.DropTable(
                name: "InvestigateCards");
        }
    }
}
