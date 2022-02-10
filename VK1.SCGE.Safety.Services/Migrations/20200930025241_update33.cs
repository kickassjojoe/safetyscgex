using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubContacts_Name",
                table: "SubContacts");

            migrationBuilder.CreateIndex(
                name: "IX_SubContacts_Name",
                table: "SubContacts",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubContacts_Name",
                table: "SubContacts");

            migrationBuilder.CreateIndex(
                name: "IX_SubContacts_Name",
                table: "SubContacts",
                column: "Name",
                unique: true);
        }
    }
}
