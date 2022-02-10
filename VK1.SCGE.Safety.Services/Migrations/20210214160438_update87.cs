using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations {
    public partial class update87 : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_PenaltyNotices_InvestigateCards_InvestigateCardId",
                table: "PenaltyNotices");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "LeaveBranchTime",
                table: "PartTwos",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddForeignKey(
                name: "FK_PenaltyNotices_InvestigateCards_InvestigateCardId",
                table: "PenaltyNotices",
                column: "InvestigateCardId",
                principalTable: "InvestigateCards",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_PenaltyNotices_InvestigateCards_InvestigateCardId",
                table: "PenaltyNotices");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "LeaveBranchTime",
                table: "PartTwos",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PenaltyNotices_InvestigateCards_InvestigateCardId",
                table: "PenaltyNotices",
                column: "InvestigateCardId",
                principalTable: "InvestigateCards",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
