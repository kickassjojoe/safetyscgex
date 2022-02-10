using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update47 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_Branches_BranchCode1",
                table: "PartOnes");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_Employees_EmployeeCode1",
                table: "PartOnes");

            migrationBuilder.DropIndex(
                name: "IX_PartOnes_BranchCode1",
                table: "PartOnes");

            migrationBuilder.DropIndex(
                name: "IX_PartOnes_EmployeeCode1",
                table: "PartOnes");

            migrationBuilder.DropColumn(
                name: "BranchCode1",
                table: "PartOnes");

            migrationBuilder.DropColumn(
                name: "EmployeeCode1",
                table: "PartOnes");

            migrationBuilder.CreateIndex(
                name: "IX_PartOnes_BranchCode",
                table: "PartOnes",
                column: "BranchCode");

            migrationBuilder.CreateIndex(
                name: "IX_PartOnes_EmployeeCode",
                table: "PartOnes",
                column: "EmployeeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_Branches_BranchCode",
                table: "PartOnes",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "BranchCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_Employees_EmployeeCode",
                table: "PartOnes",
                column: "EmployeeCode",
                principalTable: "Employees",
                principalColumn: "EmployeeCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_Branches_BranchCode",
                table: "PartOnes");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_Employees_EmployeeCode",
                table: "PartOnes");

            migrationBuilder.DropIndex(
                name: "IX_PartOnes_BranchCode",
                table: "PartOnes");

            migrationBuilder.DropIndex(
                name: "IX_PartOnes_EmployeeCode",
                table: "PartOnes");

            migrationBuilder.AddColumn<string>(
                name: "BranchCode1",
                table: "PartOnes",
                type: "nvarchar(15)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeCode1",
                table: "PartOnes",
                type: "nvarchar(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartOnes_BranchCode1",
                table: "PartOnes",
                column: "BranchCode1");

            migrationBuilder.CreateIndex(
                name: "IX_PartOnes_EmployeeCode1",
                table: "PartOnes",
                column: "EmployeeCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_Branches_BranchCode1",
                table: "PartOnes",
                column: "BranchCode1",
                principalTable: "Branches",
                principalColumn: "BranchCode",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_Employees_EmployeeCode1",
                table: "PartOnes",
                column: "EmployeeCode1",
                principalTable: "Employees",
                principalColumn: "EmployeeCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
