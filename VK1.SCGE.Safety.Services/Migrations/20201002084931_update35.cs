using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TruckInspectionCards_CardControl_CardControlCode",
                table: "TruckInspectionCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardControl",
                table: "CardControl");

            migrationBuilder.RenameTable(
                name: "CardControl",
                newName: "CardControls");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardControls",
                table: "CardControls",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckInspectionCards_CardControls_CardControlCode",
                table: "TruckInspectionCards",
                column: "CardControlCode",
                principalTable: "CardControls",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TruckInspectionCards_CardControls_CardControlCode",
                table: "TruckInspectionCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardControls",
                table: "CardControls");

            migrationBuilder.RenameTable(
                name: "CardControls",
                newName: "CardControl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardControl",
                table: "CardControl",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckInspectionCards_CardControl_CardControlCode",
                table: "TruckInspectionCards",
                column: "CardControlCode",
                principalTable: "CardControl",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
