using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update74 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartSix_InvestigateCards_InvestigateCardId",
                table: "PartSix");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartSix",
                table: "PartSix");

            migrationBuilder.RenameTable(
                name: "PartSix",
                newName: "PartSixes");

            migrationBuilder.RenameIndex(
                name: "IX_PartSix_InvestigateCardId",
                table: "PartSixes",
                newName: "IX_PartSixes_InvestigateCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartSixes",
                table: "PartSixes",
                column: "PartSixId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartSixes_InvestigateCards_InvestigateCardId",
                table: "PartSixes",
                column: "InvestigateCardId",
                principalTable: "InvestigateCards",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartSixes_InvestigateCards_InvestigateCardId",
                table: "PartSixes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartSixes",
                table: "PartSixes");

            migrationBuilder.RenameTable(
                name: "PartSixes",
                newName: "PartSix");

            migrationBuilder.RenameIndex(
                name: "IX_PartSixes_InvestigateCardId",
                table: "PartSix",
                newName: "IX_PartSix_InvestigateCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartSix",
                table: "PartSix",
                column: "PartSixId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartSix_InvestigateCards_InvestigateCardId",
                table: "PartSix",
                column: "InvestigateCardId",
                principalTable: "InvestigateCards",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
