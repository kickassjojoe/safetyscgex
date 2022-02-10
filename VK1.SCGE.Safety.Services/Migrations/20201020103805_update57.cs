using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update57 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathPictureAfterIncident",
                table: "PartThrees");

            migrationBuilder.DropColumn(
                name: "PathPictureArea",
                table: "PartThrees");

            migrationBuilder.DropColumn(
                name: "PathPictureBeforeIncident",
                table: "PartThrees");

            migrationBuilder.DropColumn(
                name: "PathPictureIncident",
                table: "PartThrees");

            migrationBuilder.AddColumn<string>(
                name: "ImageAfterIncidentName",
                table: "PartThrees",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageBeforeIncidenName",
                table: "PartThrees",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageIncidentAreaName",
                table: "PartThrees",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageIncidentName",
                table: "PartThrees",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageAfterIncidentName",
                table: "PartThrees");

            migrationBuilder.DropColumn(
                name: "ImageBeforeIncidenName",
                table: "PartThrees");

            migrationBuilder.DropColumn(
                name: "ImageIncidentAreaName",
                table: "PartThrees");

            migrationBuilder.DropColumn(
                name: "ImageIncidentName",
                table: "PartThrees");

            migrationBuilder.AddColumn<string>(
                name: "PathPictureAfterIncident",
                table: "PartThrees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathPictureArea",
                table: "PartThrees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathPictureBeforeIncident",
                table: "PartThrees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathPictureIncident",
                table: "PartThrees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
