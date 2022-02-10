using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update69 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_InvestigateCards_InvestigateCardId",
                table: "PartOnes");

            migrationBuilder.DropIndex(
                name: "IX_PartOnes_InvestigateCardId",
                table: "PartOnes");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PartOnes_InvestigateCardId",
                table: "PartOnes",
                column: "InvestigateCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestigateCards_PartOnes_InvestigateCardId",
                table: "InvestigateCards",
                column: "InvestigateCardId",
                principalTable: "PartOnes",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestigateCards_PartOnes_InvestigateCardId",
                table: "InvestigateCards");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PartOnes_InvestigateCardId",
                table: "PartOnes");

            migrationBuilder.CreateIndex(
                name: "IX_PartOnes_InvestigateCardId",
                table: "PartOnes",
                column: "InvestigateCardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_InvestigateCards_InvestigateCardId",
                table: "PartOnes",
                column: "InvestigateCardId",
                principalTable: "InvestigateCards",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
