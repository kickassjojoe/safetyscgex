using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartTwos",
                columns: table => new
                {
                    PartTwoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    InvestigateCardId = table.Column<Guid>(nullable: false),
                    LeaveBranchTime = table.Column<TimeSpan>(nullable: false),
                    LeisureHour = table.Column<int>(nullable: false),
                    IncidentRoute = table.Column<string>(nullable: false),
                    IsProduct = table.Column<bool>(nullable: false),
                    ProductQuantity = table.Column<int>(nullable: false),
                    ProductValue = table.Column<decimal>(nullable: false),
                    CaseEffect = table.Column<string>(nullable: false),
                    ProductPostpone = table.Column<int>(nullable: false),
                    EmpInjure = table.Column<string>(nullable: false),
                    EmpInjureDescription = table.Column<string>(maxLength: 500, nullable: true),
                    StopWorking = table.Column<int>(nullable: false),
                    PartiesInjure = table.Column<string>(nullable: false),
                    PartiesInjureDescription = table.Column<string>(maxLength: 500, nullable: true),
                    PartiesDie = table.Column<int>(nullable: false),
                    ThirdPartiesInjure = table.Column<string>(nullable: false),
                    ThirdPartiesInjureDescription = table.Column<string>(maxLength: 500, nullable: true),
                    ThirdPartiesDie = table.Column<int>(nullable: false),
                    TruckDamage = table.Column<string>(nullable: false),
                    TruckDamageDescription = table.Column<string>(maxLength: 500, nullable: true),
                    PartiesDamage = table.Column<string>(nullable: false),
                    PartiesDamageDescription = table.Column<string>(maxLength: 500, nullable: true),
                    EquipmentDamage = table.Column<string>(nullable: false),
                    EquipmentDamageDescription = table.Column<string>(maxLength: 500, nullable: true),
                    IsTruckInspectionNormal = table.Column<bool>(nullable: false),
                    IsGps = table.Column<bool>(nullable: false),
                    GpsSpeed = table.Column<int>(nullable: true),
                    GpsSpeedLimit = table.Column<int>(nullable: true),
                    IsCctv = table.Column<bool>(nullable: false),
                    IsPassAlcohol = table.Column<bool>(nullable: false),
                    Training = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartTwos", x => x.PartTwoId);
                    table.ForeignKey(
                        name: "FK_PartTwos_InvestigateCards_InvestigateCardId",
                        column: x => x.InvestigateCardId,
                        principalTable: "InvestigateCards",
                        principalColumn: "InvestigateCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartTwos_InvestigateCardId",
                table: "PartTwos",
                column: "InvestigateCardId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartTwos");
        }
    }
}
