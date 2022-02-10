using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Region_RegionId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RegionCode",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "Vehicles",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Region_RegionId",
                table: "Vehicles",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Region_RegionId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "RegionCode",
                table: "Vehicles",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Region_RegionId",
                table: "Vehicles",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
