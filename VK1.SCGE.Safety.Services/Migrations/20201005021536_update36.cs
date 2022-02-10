using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Branches_BranchCode",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "TruckInspectionCards",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "TruckInspectionCards",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "TruckInspectionCards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "TruckInspectionCards",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Branches_BranchCode",
                table: "Vehicles",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "BranchCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Branches_BranchCode",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "TruckInspectionCards");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "TruckInspectionCards");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "TruckInspectionCards");

            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "TruckInspectionCards");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Branches_BranchCode",
                table: "Vehicles",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "BranchCode",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
