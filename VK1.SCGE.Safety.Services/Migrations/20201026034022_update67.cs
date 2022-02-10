using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update67 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartFives_InvestigateCardId",
                table: "PartFives");

            migrationBuilder.CreateIndex(
                name: "IX_PartFives_InvestigateCardId",
                table: "PartFives",
                column: "InvestigateCardId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PartFives_InvestigateCardId",
                table: "PartFives");

            migrationBuilder.CreateIndex(
                name: "IX_PartFives_InvestigateCardId",
                table: "PartFives",
                column: "InvestigateCardId");
        }
    }
}
