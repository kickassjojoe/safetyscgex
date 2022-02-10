using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "CorrectiveActionRequests",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "CorrectiveActionRequests",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "CorrectiveActionRequests");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "CorrectiveActionRequests");
        }
    }
}
