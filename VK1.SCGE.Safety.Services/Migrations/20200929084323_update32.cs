using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubContactId",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_SubContactId",
                table: "Vehicles",
                column: "SubContactId",
                unique: true,
                filter: "[SubContactId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_SubContacts_SubContactId",
                table: "Vehicles",
                column: "SubContactId",
                principalTable: "SubContacts",
                principalColumn: "SubContactId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_SubContacts_SubContactId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_SubContactId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "SubContactId",
                table: "Vehicles");
        }
    }
}
