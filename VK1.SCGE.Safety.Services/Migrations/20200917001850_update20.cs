using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActionRequests_BranchCode",
                table: "CorrectiveActionRequests",
                column: "BranchCode");

            migrationBuilder.AddForeignKey(
                name: "FK_CorrectiveActionRequests_Branches_BranchCode",
                table: "CorrectiveActionRequests",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "BranchCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CorrectiveActionRequests_Branches_BranchCode",
                table: "CorrectiveActionRequests");

            migrationBuilder.DropIndex(
                name: "IX_CorrectiveActionRequests_BranchCode",
                table: "CorrectiveActionRequests");
        }
    }
}
