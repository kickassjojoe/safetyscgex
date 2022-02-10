using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Branches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_RegionId",
                table: "Branches",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Regions_RegionId",
                table: "Branches",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Regions_RegionId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_RegionId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Branches");
        }
    }
}
