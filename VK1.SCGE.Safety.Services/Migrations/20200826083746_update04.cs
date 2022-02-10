using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchCode = table.Column<string>(maxLength: 15, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchCode);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    PlateNumber = table.Column<string>(maxLength: 20, nullable: false),
                    RegionCode = table.Column<string>(maxLength: 15, nullable: true),
                    BranchCode = table.Column<string>(maxLength: 15, nullable: true),
                    Brand = table.Column<string>(maxLength: 100, nullable: true),
                    GpsProvider = table.Column<string>(maxLength: 100, nullable: true),
                    VehicleType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Branches_BranchCode",
                        column: x => x.BranchCode,
                        principalTable: "Branches",
                        principalColumn: "BranchCode",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TruckInspectionCards",
                columns: table => new
                {
                    TruckInspectionCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    EmployeeCode = table.Column<string>(maxLength: 11, nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    VehicleId = table.Column<int>(nullable: false),
                    PlateNumber = table.Column<string>(maxLength: 20, nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartOdometer = table.Column<int>(nullable: false),
                    FinishedOdometer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckInspectionCards", x => x.TruckInspectionCardId);
                    table.ForeignKey(
                        name: "FK_TruckInspectionCards_Employees_EmployeeCode",
                        column: x => x.EmployeeCode,
                        principalTable: "Employees",
                        principalColumn: "EmployeeCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TruckInspectionCards_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TruckInspectionCardDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    TruckInspectionCardId = table.Column<int>(nullable: true),
                    TruckInspectionItemId = table.Column<int>(nullable: false),
                    IsNormal = table.Column<bool>(nullable: true),
                    PicturePath = table.Column<string>(maxLength: 100, nullable: true),
                    Remark = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckInspectionCardDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TruckInspectionCardDetails_TruckInspectionCards_TruckInspectionCardId",
                        column: x => x.TruckInspectionCardId,
                        principalTable: "TruckInspectionCards",
                        principalColumn: "TruckInspectionCardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TruckInspectionCardDetails_TruckInspectionItems_TruckInspectionItemId",
                        column: x => x.TruckInspectionItemId,
                        principalTable: "TruckInspectionItems",
                        principalColumn: "TruckInspectionItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Name",
                table: "Branches",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TruckInspectionCardDetails_TruckInspectionCardId",
                table: "TruckInspectionCardDetails",
                column: "TruckInspectionCardId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckInspectionCardDetails_TruckInspectionItemId",
                table: "TruckInspectionCardDetails",
                column: "TruckInspectionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TruckInspectionCards_EmployeeCode",
                table: "TruckInspectionCards",
                column: "EmployeeCode");

            migrationBuilder.CreateIndex(
                name: "IX_TruckInspectionCards_VehicleId",
                table: "TruckInspectionCards",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BranchCode",
                table: "Vehicles",
                column: "BranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PlateNumber",
                table: "Vehicles",
                column: "PlateNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckInspectionCardDetails");

            migrationBuilder.DropTable(
                name: "TruckInspectionCards");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
