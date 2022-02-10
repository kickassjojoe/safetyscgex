using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update62 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreaConditionDescription",
                table: "PartFours",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncidentAreaDescription",
                table: "PartFours",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncidentRoadDescription",
                table: "PartFours",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncidentTruckDescription",
                table: "PartFours",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncidentTruckPositionDescription",
                table: "PartFours",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaConditionDescription",
                table: "PartFours");

            migrationBuilder.DropColumn(
                name: "IncidentAreaDescription",
                table: "PartFours");

            migrationBuilder.DropColumn(
                name: "IncidentRoadDescription",
                table: "PartFours");

            migrationBuilder.DropColumn(
                name: "IncidentTruckDescription",
                table: "PartFours");

            migrationBuilder.DropColumn(
                name: "IncidentTruckPositionDescription",
                table: "PartFours");
        }
    }
}
