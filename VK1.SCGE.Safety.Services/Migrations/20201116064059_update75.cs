using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update75 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartSixes_InvestigateCardId",
                table: "PartSixes");

            migrationBuilder.CreateIndex(
                name: "IX_PartSixes_InvestigateCardId",
                table: "PartSixes",
                column: "InvestigateCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartSixes_InvestigateCardId",
                table: "PartSixes");

            migrationBuilder.CreateIndex(
                name: "IX_PartSixes_InvestigateCardId",
                table: "PartSixes",
                column: "InvestigateCardId",
                unique: true);
        }
    }
}
