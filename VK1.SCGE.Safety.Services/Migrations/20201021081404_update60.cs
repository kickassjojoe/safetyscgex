using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update60 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaConditions",
                columns: table => new
                {
                    AreaConditionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaConditions", x => x.AreaConditionId);
                });

            migrationBuilder.CreateTable(
                name: "IncidentAreas",
                columns: table => new
                {
                    IncidentAreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentAreas", x => x.IncidentAreaId);
                });

            migrationBuilder.CreateTable(
                name: "IncidentDepots",
                columns: table => new
                {
                    IncidentDepotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentDepots", x => x.IncidentDepotId);
                });

            migrationBuilder.CreateTable(
                name: "IncidentRoads",
                columns: table => new
                {
                    IncidentRoadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentRoads", x => x.IncidentRoadId);
                });

            migrationBuilder.CreateTable(
                name: "IncidentTruckPositons",
                columns: table => new
                {
                    IncidentTruckPositonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTruckPositons", x => x.IncidentTruckPositonId);
                });

            migrationBuilder.CreateTable(
                name: "IncidentTrucks",
                columns: table => new
                {
                    IncidentTruckId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTrucks", x => x.IncidentTruckId);
                });

            migrationBuilder.CreateTable(
                name: "Traffics",
                columns: table => new
                {
                    TrafficId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traffics", x => x.TrafficId);
                });

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    WeatherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.WeatherId);
                });

            migrationBuilder.CreateTable(
                name: "PartFours",
                columns: table => new
                {
                    PartFourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    InvestigateCardId = table.Column<Guid>(nullable: false),
                    IncidentTruckId = table.Column<int>(nullable: false),
                    IncidentTruckPositonId = table.Column<int>(nullable: false),
                    IncidentAreaId = table.Column<int>(nullable: false),
                    IncidentRoadId = table.Column<int>(nullable: false),
                    AreaConditionId = table.Column<int>(nullable: false),
                    WeatherId = table.Column<int>(nullable: false),
                    WeatherDescription = table.Column<string>(maxLength: 500, nullable: true),
                    TrafficId = table.Column<int>(nullable: false),
                    IncidentDepotId = table.Column<int>(nullable: false),
                    FallFromHeight = table.Column<int>(nullable: false),
                    IncidentDepotDescription = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartFours", x => x.PartFourId);
                    table.ForeignKey(
                        name: "FK_PartFours_AreaConditions_AreaConditionId",
                        column: x => x.AreaConditionId,
                        principalTable: "AreaConditions",
                        principalColumn: "AreaConditionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartFours_IncidentAreas_IncidentAreaId",
                        column: x => x.IncidentAreaId,
                        principalTable: "IncidentAreas",
                        principalColumn: "IncidentAreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartFours_IncidentDepots_IncidentDepotId",
                        column: x => x.IncidentDepotId,
                        principalTable: "IncidentDepots",
                        principalColumn: "IncidentDepotId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartFours_IncidentRoads_IncidentRoadId",
                        column: x => x.IncidentRoadId,
                        principalTable: "IncidentRoads",
                        principalColumn: "IncidentRoadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartFours_IncidentTrucks_IncidentTruckId",
                        column: x => x.IncidentTruckId,
                        principalTable: "IncidentTrucks",
                        principalColumn: "IncidentTruckId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartFours_IncidentTruckPositons_IncidentTruckPositonId",
                        column: x => x.IncidentTruckPositonId,
                        principalTable: "IncidentTruckPositons",
                        principalColumn: "IncidentTruckPositonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartFours_InvestigateCards_InvestigateCardId",
                        column: x => x.InvestigateCardId,
                        principalTable: "InvestigateCards",
                        principalColumn: "InvestigateCardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartFours_Traffics_TrafficId",
                        column: x => x.TrafficId,
                        principalTable: "Traffics",
                        principalColumn: "TrafficId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartFours_Weathers_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weathers",
                        principalColumn: "WeatherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartFours_AreaConditionId",
                table: "PartFours",
                column: "AreaConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartFours_IncidentAreaId",
                table: "PartFours",
                column: "IncidentAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PartFours_IncidentDepotId",
                table: "PartFours",
                column: "IncidentDepotId");

            migrationBuilder.CreateIndex(
                name: "IX_PartFours_IncidentRoadId",
                table: "PartFours",
                column: "IncidentRoadId");

            migrationBuilder.CreateIndex(
                name: "IX_PartFours_IncidentTruckId",
                table: "PartFours",
                column: "IncidentTruckId");

            migrationBuilder.CreateIndex(
                name: "IX_PartFours_IncidentTruckPositonId",
                table: "PartFours",
                column: "IncidentTruckPositonId");

            migrationBuilder.CreateIndex(
                name: "IX_PartFours_InvestigateCardId",
                table: "PartFours",
                column: "InvestigateCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartFours_TrafficId",
                table: "PartFours",
                column: "TrafficId");

            migrationBuilder.CreateIndex(
                name: "IX_PartFours_WeatherId",
                table: "PartFours",
                column: "WeatherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartFours");

            migrationBuilder.DropTable(
                name: "AreaConditions");

            migrationBuilder.DropTable(
                name: "IncidentAreas");

            migrationBuilder.DropTable(
                name: "IncidentDepots");

            migrationBuilder.DropTable(
                name: "IncidentRoads");

            migrationBuilder.DropTable(
                name: "IncidentTrucks");

            migrationBuilder.DropTable(
                name: "IncidentTruckPositons");

            migrationBuilder.DropTable(
                name: "Traffics");

            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
