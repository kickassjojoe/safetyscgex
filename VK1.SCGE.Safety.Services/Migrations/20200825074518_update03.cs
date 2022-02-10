using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TruckInspectionItems_TruckInspectionCategories_TruckInspectionCategoryId",
                table: "TruckInspectionItems");

            migrationBuilder.AlterColumn<int>(
                name: "TruckInspectionCategoryId",
                table: "TruckInspectionItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TruckInspectionCategories_Name",
                table: "TruckInspectionCategories",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TruckInspectionItems_TruckInspectionCategories_TruckInspectionCategoryId",
                table: "TruckInspectionItems",
                column: "TruckInspectionCategoryId",
                principalTable: "TruckInspectionCategories",
                principalColumn: "TruckInspectionCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TruckInspectionItems_TruckInspectionCategories_TruckInspectionCategoryId",
                table: "TruckInspectionItems");

            migrationBuilder.DropIndex(
                name: "IX_TruckInspectionCategories_Name",
                table: "TruckInspectionCategories");

            migrationBuilder.AlterColumn<int>(
                name: "TruckInspectionCategoryId",
                table: "TruckInspectionItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TruckInspectionItems_TruckInspectionCategories_TruckInspectionCategoryId",
                table: "TruckInspectionItems",
                column: "TruckInspectionCategoryId",
                principalTable: "TruckInspectionCategories",
                principalColumn: "TruckInspectionCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
