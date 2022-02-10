using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TruckInspectionCategoryId",
                table: "TruckInspectionCards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TruckInspectionCards_TruckInspectionCategoryId",
                table: "TruckInspectionCards",
                column: "TruckInspectionCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckInspectionCards_TruckInspectionCategories_TruckInspectionCategoryId",
                table: "TruckInspectionCards",
                column: "TruckInspectionCategoryId",
                principalTable: "TruckInspectionCategories",
                principalColumn: "TruckInspectionCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TruckInspectionCards_TruckInspectionCategories_TruckInspectionCategoryId",
                table: "TruckInspectionCards");

            migrationBuilder.DropIndex(
                name: "IX_TruckInspectionCards_TruckInspectionCategoryId",
                table: "TruckInspectionCards");

            migrationBuilder.DropColumn(
                name: "TruckInspectionCategoryId",
                table: "TruckInspectionCards");
        }
    }
}
