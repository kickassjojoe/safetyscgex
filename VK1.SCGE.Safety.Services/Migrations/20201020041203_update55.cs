using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartThrees",
                columns: table => new
                {
                    PartThreeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigateCardId = table.Column<Guid>(nullable: false),
                    BeforeIncidentDescription = table.Column<string>(maxLength: 500, nullable: true),
                    IncidentDescription = table.Column<string>(maxLength: 500, nullable: true),
                    AfterIncidentDescription = table.Column<string>(maxLength: 500, nullable: true),
                    PathPictureBeforeIncident = table.Column<string>(maxLength: 100, nullable: true),
                    PathPictureIncident = table.Column<string>(maxLength: 100, nullable: true),
                    PathPictureAfterIncident = table.Column<string>(maxLength: 100, nullable: true),
                    PathPictureArea = table.Column<string>(maxLength: 100, nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartThrees", x => x.PartThreeId);
                    table.ForeignKey(
                        name: "FK_PartThrees_InvestigateCards_InvestigateCardId",
                        column: x => x.InvestigateCardId,
                        principalTable: "InvestigateCards",
                        principalColumn: "InvestigateCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartThrees_InvestigateCardId",
                table: "PartThrees",
                column: "InvestigateCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartThrees");
        }
    }
}
