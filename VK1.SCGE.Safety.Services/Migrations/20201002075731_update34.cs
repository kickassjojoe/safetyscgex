using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardControlCode",
                table: "TruckInspectionCards",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextCardTruckInspectionCardId",
                table: "TruckInspectionCards",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CardControl",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 6, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardControl", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TruckInspectionCards_CardControlCode",
                table: "TruckInspectionCards",
                column: "CardControlCode");

            migrationBuilder.CreateIndex(
                name: "IX_TruckInspectionCards_NextCardTruckInspectionCardId",
                table: "TruckInspectionCards",
                column: "NextCardTruckInspectionCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_TruckInspectionCards_CardControl_CardControlCode",
                table: "TruckInspectionCards",
                column: "CardControlCode",
                principalTable: "CardControl",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TruckInspectionCards_TruckInspectionCards_NextCardTruckInspectionCardId",
                table: "TruckInspectionCards",
                column: "NextCardTruckInspectionCardId",
                principalTable: "TruckInspectionCards",
                principalColumn: "TruckInspectionCardId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TruckInspectionCards_CardControl_CardControlCode",
                table: "TruckInspectionCards");

            migrationBuilder.DropForeignKey(
                name: "FK_TruckInspectionCards_TruckInspectionCards_NextCardTruckInspectionCardId",
                table: "TruckInspectionCards");

            migrationBuilder.DropTable(
                name: "CardControl");

            migrationBuilder.DropIndex(
                name: "IX_TruckInspectionCards_CardControlCode",
                table: "TruckInspectionCards");

            migrationBuilder.DropIndex(
                name: "IX_TruckInspectionCards_NextCardTruckInspectionCardId",
                table: "TruckInspectionCards");

            migrationBuilder.DropColumn(
                name: "CardControlCode",
                table: "TruckInspectionCards");

            migrationBuilder.DropColumn(
                name: "NextCardTruckInspectionCardId",
                table: "TruckInspectionCards");
        }
    }
}
