using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "SubContacts");

            migrationBuilder.DropColumn(
                name: "IdCard",
                table: "SubContacts");

            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "SubContacts",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "SubContacts",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GpsProvider",
                table: "SubContacts",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlateNumber",
                table: "SubContacts",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "SubContacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "SubContacts",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VehicleType",
                table: "SubContacts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubContacts_BranchCode",
                table: "SubContacts",
                column: "BranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubContacts_RegionId",
                table: "SubContacts",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubContacts_Branches_BranchCode",
                table: "SubContacts",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "BranchCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubContacts_Regions_RegionId",
                table: "SubContacts",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubContacts_Branches_BranchCode",
                table: "SubContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_SubContacts_Regions_RegionId",
                table: "SubContacts");

            migrationBuilder.DropIndex(
                name: "IX_SubContacts_BranchCode",
                table: "SubContacts");

            migrationBuilder.DropIndex(
                name: "IX_SubContacts_RegionId",
                table: "SubContacts");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "SubContacts");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "SubContacts");

            migrationBuilder.DropColumn(
                name: "GpsProvider",
                table: "SubContacts");

            migrationBuilder.DropColumn(
                name: "PlateNumber",
                table: "SubContacts");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "SubContacts");

            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "SubContacts");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "SubContacts");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SubContacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdCard",
                table: "SubContacts",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true);
        }
    }
}
