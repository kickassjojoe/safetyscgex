using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update88 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PenaltyNotices_InvestigateCards_InvestigateCardId",
                table: "PenaltyNotices");

            migrationBuilder.DropIndex(
                name: "IX_PenaltyNotices_InvestigateCardId",
                table: "PenaltyNotices");

            migrationBuilder.CreateIndex(
                name: "IX_PenaltyNotices_InvestigateCardId",
                table: "PenaltyNotices",
                column: "InvestigateCardId",
                unique: true,
                filter: "[InvestigateCardId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PenaltyNotices_InvestigateCards_InvestigateCardId",
                table: "PenaltyNotices",
                column: "InvestigateCardId",
                principalTable: "InvestigateCards",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PenaltyNotices_InvestigateCards_InvestigateCardId",
                table: "PenaltyNotices");

            migrationBuilder.DropIndex(
                name: "IX_PenaltyNotices_InvestigateCardId",
                table: "PenaltyNotices");

            migrationBuilder.CreateIndex(
                name: "IX_PenaltyNotices_InvestigateCardId",
                table: "PenaltyNotices",
                column: "InvestigateCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_PenaltyNotices_InvestigateCards_InvestigateCardId",
                table: "PenaltyNotices",
                column: "InvestigateCardId",
                principalTable: "InvestigateCards",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
