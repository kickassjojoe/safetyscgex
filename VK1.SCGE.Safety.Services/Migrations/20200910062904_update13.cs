using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorrectiveActionRequestStatuses",
                columns: table => new
                {
                    CARStatusCode = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveActionRequestStatuses", x => x.CARStatusCode);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveActionRequests",
                columns: table => new
                {
                    CARCode = table.Column<string>(maxLength: 20, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    ViewerName = table.Column<string>(maxLength: 200, nullable: true),
                    ViewerEmail = table.Column<string>(maxLength: 200, nullable: true),
                    ViewerDepartment = table.Column<string>(maxLength: 200, nullable: true),
                    ViewerDivision = table.Column<string>(maxLength: 200, nullable: true),
                    VehicleType = table.Column<int>(nullable: false),
                    PlateNumber = table.Column<string>(maxLength: 20, nullable: false),
                    VehicleId = table.Column<int>(nullable: true),
                    CARStatusCode = table.Column<string>(maxLength: 3, nullable: true),
                    CARStatusName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveActionRequests", x => x.CARCode);
                    table.ForeignKey(
                        name: "FK_CorrectiveActionRequests_CorrectiveActionRequestStatuses_CARStatusCode",
                        column: x => x.CARStatusCode,
                        principalTable: "CorrectiveActionRequestStatuses",
                        principalColumn: "CARStatusCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorrectiveActionRequests_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveActionRequestItems",
                columns: table => new
                {
                    CARItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CARCode = table.Column<string>(maxLength: 20, nullable: false),
                    TruckInspectionCardDetailId = table.Column<int>(nullable: true),
                    TruckInspectionCategoryId = table.Column<int>(nullable: true),
                    TruckInspectionCategoryName = table.Column<string>(maxLength: 200, nullable: true),
                    TruckInspectionItemId = table.Column<int>(nullable: true),
                    TruckInspectionItemName = table.Column<string>(maxLength: 200, nullable: true),
                    IsFixed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveActionRequestItems", x => x.CARItemId);
                    table.ForeignKey(
                        name: "FK_CorrectiveActionRequestItems_CorrectiveActionRequests_CARCode",
                        column: x => x.CARCode,
                        principalTable: "CorrectiveActionRequests",
                        principalColumn: "CARCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorrectiveActionRequestItems_TruckInspectionCardDetails_TruckInspectionCardDetailId",
                        column: x => x.TruckInspectionCardDetailId,
                        principalTable: "TruckInspectionCardDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorrectiveActionRequestItems_TruckInspectionCategories_TruckInspectionCategoryId",
                        column: x => x.TruckInspectionCategoryId,
                        principalTable: "TruckInspectionCategories",
                        principalColumn: "TruckInspectionCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CorrectiveActionRequestItems_TruckInspectionItems_TruckInspectionItemId",
                        column: x => x.TruckInspectionItemId,
                        principalTable: "TruckInspectionItems",
                        principalColumn: "TruckInspectionItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActionRequestItems_CARCode",
                table: "CorrectiveActionRequestItems",
                column: "CARCode");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActionRequestItems_TruckInspectionCardDetailId",
                table: "CorrectiveActionRequestItems",
                column: "TruckInspectionCardDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActionRequestItems_TruckInspectionCategoryId",
                table: "CorrectiveActionRequestItems",
                column: "TruckInspectionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActionRequestItems_TruckInspectionItemId",
                table: "CorrectiveActionRequestItems",
                column: "TruckInspectionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActionRequests_CARStatusCode",
                table: "CorrectiveActionRequests",
                column: "CARStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActionRequests_VehicleId",
                table: "CorrectiveActionRequests",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrectiveActionRequestItems");

            migrationBuilder.DropTable(
                name: "CorrectiveActionRequests");

            migrationBuilder.DropTable(
                name: "CorrectiveActionRequestStatuses");
        }
    }
}
