using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update79 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PartSixes_UnsafeItemCode",
                table: "PartSixes",
                column: "UnsafeItemCode");

            migrationBuilder.AddForeignKey(
                name: "FK_PartSixes_UnsafeItems_UnsafeItemCode",
                table: "PartSixes",
                column: "UnsafeItemCode",
                principalTable: "UnsafeItems",
                principalColumn: "UnsafeItemCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartSixes_UnsafeItems_UnsafeItemCode",
                table: "PartSixes");

            migrationBuilder.DropIndex(
                name: "IX_PartSixes_UnsafeItemCode",
                table: "PartSixes");
        }
    }
}
