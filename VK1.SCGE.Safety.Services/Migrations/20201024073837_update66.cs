using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update66 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnsafeItems_UnsafeCategories_UnsafeCategoryCode",
                table: "UnsafeItems");

            migrationBuilder.AlterColumn<string>(
                name: "UnsafeCategoryCode",
                table: "UnsafeItems",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UnsafeItems_UnsafeCategories_UnsafeCategoryCode",
                table: "UnsafeItems",
                column: "UnsafeCategoryCode",
                principalTable: "UnsafeCategories",
                principalColumn: "UnsafeCategoryCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnsafeItems_UnsafeCategories_UnsafeCategoryCode",
                table: "UnsafeItems");

            migrationBuilder.AlterColumn<string>(
                name: "UnsafeCategoryCode",
                table: "UnsafeItems",
                type: "nvarchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_UnsafeItems_UnsafeCategories_UnsafeCategoryCode",
                table: "UnsafeItems",
                column: "UnsafeCategoryCode",
                principalTable: "UnsafeCategories",
                principalColumn: "UnsafeCategoryCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
