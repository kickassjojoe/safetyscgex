using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update85 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_IncidentDepots_IncidentDepotId",
                table: "PartFours");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_IncidentRoads_IncidentRoadId",
                table: "PartFours");

            migrationBuilder.AlterColumn<int>(
                name: "IncidentRoadId",
                table: "PartFours",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IncidentDepotId",
                table: "PartFours",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PartFours_IncidentDepots_IncidentDepotId",
                table: "PartFours",
                column: "IncidentDepotId",
                principalTable: "IncidentDepots",
                principalColumn: "IncidentDepotId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFours_IncidentRoads_IncidentRoadId",
                table: "PartFours",
                column: "IncidentRoadId",
                principalTable: "IncidentRoads",
                principalColumn: "IncidentRoadId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_IncidentDepots_IncidentDepotId",
                table: "PartFours");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_IncidentRoads_IncidentRoadId",
                table: "PartFours");

            migrationBuilder.AlterColumn<int>(
                name: "IncidentRoadId",
                table: "PartFours",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IncidentDepotId",
                table: "PartFours",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFours_IncidentDepots_IncidentDepotId",
                table: "PartFours",
                column: "IncidentDepotId",
                principalTable: "IncidentDepots",
                principalColumn: "IncidentDepotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFours_IncidentRoads_IncidentRoadId",
                table: "PartFours",
                column: "IncidentRoadId",
                principalTable: "IncidentRoads",
                principalColumn: "IncidentRoadId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
