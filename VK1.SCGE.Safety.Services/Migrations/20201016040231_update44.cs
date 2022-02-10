using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update44 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransportLicense",
                table: "PartOnes");

            migrationBuilder.AddColumn<string>(
                name: "PlateNumber",
                table: "PartOnes",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "PartOnes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PartOnes_VehicleId",
                table: "PartOnes",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_Vehicles_VehicleId",
                table: "PartOnes",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_Vehicles_VehicleId",
                table: "PartOnes");

            migrationBuilder.DropIndex(
                name: "IX_PartOnes_VehicleId",
                table: "PartOnes");

            migrationBuilder.DropColumn(
                name: "PlateNumber",
                table: "PartOnes");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "PartOnes");

            migrationBuilder.AddColumn<string>(
                name: "TransportLicense",
                table: "PartOnes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
