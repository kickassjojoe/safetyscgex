using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartThrees_InvestigateCardId",
                table: "PartThrees");

            migrationBuilder.CreateIndex(
                name: "IX_PartThrees_InvestigateCardId",
                table: "PartThrees",
                column: "InvestigateCardId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartThrees_InvestigateCardId",
                table: "PartThrees");

            migrationBuilder.CreateIndex(
                name: "IX_PartThrees_InvestigateCardId",
                table: "PartThrees",
                column: "InvestigateCardId");
        }
    }
}
