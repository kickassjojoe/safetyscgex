using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update70 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestigateCards_PartOnes_InvestigateCardId",
                table: "InvestigateCards");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFiveDetails_PartFives_PartFiveId",
                table: "PartFiveDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFiveDetails_UnsafeCategories_UnsafeCategoryCode",
                table: "PartFiveDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFiveDetails_UnsafeItems_UnsafeItemCode",
                table: "PartFiveDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFives_InvestigateCards_InvestigateCardId",
                table: "PartFives");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_AreaConditions_AreaConditionId",
                table: "PartFours");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_IncidentAreas_IncidentAreaId",
                table: "PartFours");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_IncidentDepots_IncidentDepotId",
                table: "PartFours");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_IncidentRoads_IncidentRoadId",
                table: "PartFours");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_IncidentTrucks_IncidentTruckId",
                table: "PartFours");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_IncidentTruckPositons_IncidentTruckPositonId",
                table: "PartFours");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_InvestigateCards_InvestigateCardId",
                table: "PartFours");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_Traffics_TrafficId",
                table: "PartFours");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFours_Weathers_WeatherId",
                table: "PartFours");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_Branches_BranchCode",
                table: "PartOnes");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_Employees_EmployeeCode",
                table: "PartOnes");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_Regions_RegionId",
                table: "PartOnes");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOnes_Vehicles_VehicleId",
                table: "PartOnes");

            migrationBuilder.DropForeignKey(
                name: "FK_PartThrees_InvestigateCards_InvestigateCardId",
                table: "PartThrees");

            migrationBuilder.DropForeignKey(
                name: "FK_PartTwos_InvestigateCards_InvestigateCardId",
                table: "PartTwos");

            migrationBuilder.DropForeignKey(
                name: "FK_UnsafeItems_UnsafeCategories_UnsafeCategoryCode",
                table: "UnsafeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weathers",
                table: "Weathers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnsafeItems",
                table: "UnsafeItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnsafeCategories",
                table: "UnsafeCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Traffics",
                table: "Traffics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartTwos",
                table: "PartTwos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartThrees",
                table: "PartThrees");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_PartOnes_InvestigateCardId",
                table: "PartOnes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartOnes",
                table: "PartOnes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartFours",
                table: "PartFours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartFives",
                table: "PartFives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartFiveDetails",
                table: "PartFiveDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvestigateCards",
                table: "InvestigateCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentTrucks",
                table: "IncidentTrucks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentTruckPositons",
                table: "IncidentTruckPositons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentRoads",
                table: "IncidentRoads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentDepots",
                table: "IncidentDepots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentAreas",
                table: "IncidentAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaConditions",
                table: "AreaConditions");

            migrationBuilder.RenameTable(
                name: "Weathers",
                newName: "Weather");

            migrationBuilder.RenameTable(
                name: "UnsafeItems",
                newName: "UnsafeItem");

            migrationBuilder.RenameTable(
                name: "UnsafeCategories",
                newName: "UnsafeCategory");

            migrationBuilder.RenameTable(
                name: "Traffics",
                newName: "Traffic");

            migrationBuilder.RenameTable(
                name: "PartTwos",
                newName: "PartTwo");

            migrationBuilder.RenameTable(
                name: "PartThrees",
                newName: "PartThree");

            migrationBuilder.RenameTable(
                name: "PartOnes",
                newName: "PartOne");

            migrationBuilder.RenameTable(
                name: "PartFours",
                newName: "PartFour");

            migrationBuilder.RenameTable(
                name: "PartFives",
                newName: "PartFive");

            migrationBuilder.RenameTable(
                name: "PartFiveDetails",
                newName: "PartFiveDetail");

            migrationBuilder.RenameTable(
                name: "InvestigateCards",
                newName: "InvestigateCard");

            migrationBuilder.RenameTable(
                name: "IncidentTrucks",
                newName: "IncidentTruck");

            migrationBuilder.RenameTable(
                name: "IncidentTruckPositons",
                newName: "IncidentTruckPositon");

            migrationBuilder.RenameTable(
                name: "IncidentRoads",
                newName: "IncidentRoad");

            migrationBuilder.RenameTable(
                name: "IncidentDepots",
                newName: "IncidentDepot");

            migrationBuilder.RenameTable(
                name: "IncidentAreas",
                newName: "IncidentArea");

            migrationBuilder.RenameTable(
                name: "AreaConditions",
                newName: "AreaCondition");

            migrationBuilder.RenameIndex(
                name: "IX_UnsafeItems_UnsafeCategoryCode",
                table: "UnsafeItem",
                newName: "IX_UnsafeItem_UnsafeCategoryCode");

            migrationBuilder.RenameIndex(
                name: "IX_PartTwos_InvestigateCardId",
                table: "PartTwo",
                newName: "IX_PartTwo_InvestigateCardId");

            migrationBuilder.RenameIndex(
                name: "IX_PartThrees_InvestigateCardId",
                table: "PartThree",
                newName: "IX_PartThree_InvestigateCardId");

            migrationBuilder.RenameIndex(
                name: "IX_PartOnes_VehicleId",
                table: "PartOne",
                newName: "IX_PartOne_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_PartOnes_RegionId",
                table: "PartOne",
                newName: "IX_PartOne_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_PartOnes_EmployeeCode",
                table: "PartOne",
                newName: "IX_PartOne_EmployeeCode");

            migrationBuilder.RenameIndex(
                name: "IX_PartOnes_BranchCode",
                table: "PartOne",
                newName: "IX_PartOne_BranchCode");

            migrationBuilder.RenameIndex(
                name: "IX_PartFours_WeatherId",
                table: "PartFour",
                newName: "IX_PartFour_WeatherId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFours_TrafficId",
                table: "PartFour",
                newName: "IX_PartFour_TrafficId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFours_InvestigateCardId",
                table: "PartFour",
                newName: "IX_PartFour_InvestigateCardId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFours_IncidentTruckPositonId",
                table: "PartFour",
                newName: "IX_PartFour_IncidentTruckPositonId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFours_IncidentTruckId",
                table: "PartFour",
                newName: "IX_PartFour_IncidentTruckId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFours_IncidentRoadId",
                table: "PartFour",
                newName: "IX_PartFour_IncidentRoadId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFours_IncidentDepotId",
                table: "PartFour",
                newName: "IX_PartFour_IncidentDepotId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFours_IncidentAreaId",
                table: "PartFour",
                newName: "IX_PartFour_IncidentAreaId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFours_AreaConditionId",
                table: "PartFour",
                newName: "IX_PartFour_AreaConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFives_InvestigateCardId",
                table: "PartFive",
                newName: "IX_PartFive_InvestigateCardId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFiveDetails_UnsafeItemCode",
                table: "PartFiveDetail",
                newName: "IX_PartFiveDetail_UnsafeItemCode");

            migrationBuilder.RenameIndex(
                name: "IX_PartFiveDetails_UnsafeCategoryCode",
                table: "PartFiveDetail",
                newName: "IX_PartFiveDetail_UnsafeCategoryCode");

            migrationBuilder.RenameIndex(
                name: "IX_PartFiveDetails_PartFiveId",
                table: "PartFiveDetail",
                newName: "IX_PartFiveDetail_PartFiveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weather",
                table: "Weather",
                column: "WeatherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnsafeItem",
                table: "UnsafeItem",
                column: "UnsafeItemCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnsafeCategory",
                table: "UnsafeCategory",
                column: "UnsafeCategoryCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Traffic",
                table: "Traffic",
                column: "TrafficId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartTwo",
                table: "PartTwo",
                column: "PartTwoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartThree",
                table: "PartThree",
                column: "PartThreeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartOne",
                table: "PartOne",
                column: "PartOneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartFour",
                table: "PartFour",
                column: "PartFourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartFive",
                table: "PartFive",
                column: "PartFiveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartFiveDetail",
                table: "PartFiveDetail",
                column: "PartFiveDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvestigateCard",
                table: "InvestigateCard",
                column: "InvestigateCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentTruck",
                table: "IncidentTruck",
                column: "IncidentTruckId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentTruckPositon",
                table: "IncidentTruckPositon",
                column: "IncidentTruckPositonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentRoad",
                table: "IncidentRoad",
                column: "IncidentRoadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentDepot",
                table: "IncidentDepot",
                column: "IncidentDepotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentArea",
                table: "IncidentArea",
                column: "IncidentAreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaCondition",
                table: "AreaCondition",
                column: "AreaConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartOne_InvestigateCardId",
                table: "PartOne",
                column: "InvestigateCardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFive_InvestigateCard_InvestigateCardId",
                table: "PartFive",
                column: "InvestigateCardId",
                principalTable: "InvestigateCard",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFiveDetail_PartFive_PartFiveId",
                table: "PartFiveDetail",
                column: "PartFiveId",
                principalTable: "PartFive",
                principalColumn: "PartFiveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFiveDetail_UnsafeCategory_UnsafeCategoryCode",
                table: "PartFiveDetail",
                column: "UnsafeCategoryCode",
                principalTable: "UnsafeCategory",
                principalColumn: "UnsafeCategoryCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFiveDetail_UnsafeItem_UnsafeItemCode",
                table: "PartFiveDetail",
                column: "UnsafeItemCode",
                principalTable: "UnsafeItem",
                principalColumn: "UnsafeItemCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFour_AreaCondition_AreaConditionId",
                table: "PartFour",
                column: "AreaConditionId",
                principalTable: "AreaCondition",
                principalColumn: "AreaConditionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFour_IncidentArea_IncidentAreaId",
                table: "PartFour",
                column: "IncidentAreaId",
                principalTable: "IncidentArea",
                principalColumn: "IncidentAreaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFour_IncidentDepot_IncidentDepotId",
                table: "PartFour",
                column: "IncidentDepotId",
                principalTable: "IncidentDepot",
                principalColumn: "IncidentDepotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFour_IncidentRoad_IncidentRoadId",
                table: "PartFour",
                column: "IncidentRoadId",
                principalTable: "IncidentRoad",
                principalColumn: "IncidentRoadId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFour_IncidentTruck_IncidentTruckId",
                table: "PartFour",
                column: "IncidentTruckId",
                principalTable: "IncidentTruck",
                principalColumn: "IncidentTruckId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFour_IncidentTruckPositon_IncidentTruckPositonId",
                table: "PartFour",
                column: "IncidentTruckPositonId",
                principalTable: "IncidentTruckPositon",
                principalColumn: "IncidentTruckPositonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFour_InvestigateCard_InvestigateCardId",
                table: "PartFour",
                column: "InvestigateCardId",
                principalTable: "InvestigateCard",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFour_Traffic_TrafficId",
                table: "PartFour",
                column: "TrafficId",
                principalTable: "Traffic",
                principalColumn: "TrafficId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFour_Weather_WeatherId",
                table: "PartFour",
                column: "WeatherId",
                principalTable: "Weather",
                principalColumn: "WeatherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOne_Branches_BranchCode",
                table: "PartOne",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "BranchCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOne_Employees_EmployeeCode",
                table: "PartOne",
                column: "EmployeeCode",
                principalTable: "Employees",
                principalColumn: "EmployeeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOne_InvestigateCard_InvestigateCardId",
                table: "PartOne",
                column: "InvestigateCardId",
                principalTable: "InvestigateCard",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOne_Regions_RegionId",
                table: "PartOne",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOne_Vehicles_VehicleId",
                table: "PartOne",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartThree_InvestigateCard_InvestigateCardId",
                table: "PartThree",
                column: "InvestigateCardId",
                principalTable: "InvestigateCard",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartTwo_InvestigateCard_InvestigateCardId",
                table: "PartTwo",
                column: "InvestigateCardId",
                principalTable: "InvestigateCard",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnsafeItem_UnsafeCategory_UnsafeCategoryCode",
                table: "UnsafeItem",
                column: "UnsafeCategoryCode",
                principalTable: "UnsafeCategory",
                principalColumn: "UnsafeCategoryCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartFive_InvestigateCard_InvestigateCardId",
                table: "PartFive");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFiveDetail_PartFive_PartFiveId",
                table: "PartFiveDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFiveDetail_UnsafeCategory_UnsafeCategoryCode",
                table: "PartFiveDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFiveDetail_UnsafeItem_UnsafeItemCode",
                table: "PartFiveDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFour_AreaCondition_AreaConditionId",
                table: "PartFour");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFour_IncidentArea_IncidentAreaId",
                table: "PartFour");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFour_IncidentDepot_IncidentDepotId",
                table: "PartFour");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFour_IncidentRoad_IncidentRoadId",
                table: "PartFour");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFour_IncidentTruck_IncidentTruckId",
                table: "PartFour");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFour_IncidentTruckPositon_IncidentTruckPositonId",
                table: "PartFour");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFour_InvestigateCard_InvestigateCardId",
                table: "PartFour");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFour_Traffic_TrafficId",
                table: "PartFour");

            migrationBuilder.DropForeignKey(
                name: "FK_PartFour_Weather_WeatherId",
                table: "PartFour");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOne_Branches_BranchCode",
                table: "PartOne");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOne_Employees_EmployeeCode",
                table: "PartOne");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOne_InvestigateCard_InvestigateCardId",
                table: "PartOne");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOne_Regions_RegionId",
                table: "PartOne");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOne_Vehicles_VehicleId",
                table: "PartOne");

            migrationBuilder.DropForeignKey(
                name: "FK_PartThree_InvestigateCard_InvestigateCardId",
                table: "PartThree");

            migrationBuilder.DropForeignKey(
                name: "FK_PartTwo_InvestigateCard_InvestigateCardId",
                table: "PartTwo");

            migrationBuilder.DropForeignKey(
                name: "FK_UnsafeItem_UnsafeCategory_UnsafeCategoryCode",
                table: "UnsafeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weather",
                table: "Weather");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnsafeItem",
                table: "UnsafeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnsafeCategory",
                table: "UnsafeCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Traffic",
                table: "Traffic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartTwo",
                table: "PartTwo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartThree",
                table: "PartThree");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartOne",
                table: "PartOne");

            migrationBuilder.DropIndex(
                name: "IX_PartOne_InvestigateCardId",
                table: "PartOne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartFour",
                table: "PartFour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartFiveDetail",
                table: "PartFiveDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PartFive",
                table: "PartFive");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvestigateCard",
                table: "InvestigateCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentTruckPositon",
                table: "IncidentTruckPositon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentTruck",
                table: "IncidentTruck");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentRoad",
                table: "IncidentRoad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentDepot",
                table: "IncidentDepot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentArea",
                table: "IncidentArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaCondition",
                table: "AreaCondition");

            migrationBuilder.RenameTable(
                name: "Weather",
                newName: "Weathers");

            migrationBuilder.RenameTable(
                name: "UnsafeItem",
                newName: "UnsafeItems");

            migrationBuilder.RenameTable(
                name: "UnsafeCategory",
                newName: "UnsafeCategories");

            migrationBuilder.RenameTable(
                name: "Traffic",
                newName: "Traffics");

            migrationBuilder.RenameTable(
                name: "PartTwo",
                newName: "PartTwos");

            migrationBuilder.RenameTable(
                name: "PartThree",
                newName: "PartThrees");

            migrationBuilder.RenameTable(
                name: "PartOne",
                newName: "PartOnes");

            migrationBuilder.RenameTable(
                name: "PartFour",
                newName: "PartFours");

            migrationBuilder.RenameTable(
                name: "PartFiveDetail",
                newName: "PartFiveDetails");

            migrationBuilder.RenameTable(
                name: "PartFive",
                newName: "PartFives");

            migrationBuilder.RenameTable(
                name: "InvestigateCard",
                newName: "InvestigateCards");

            migrationBuilder.RenameTable(
                name: "IncidentTruckPositon",
                newName: "IncidentTruckPositons");

            migrationBuilder.RenameTable(
                name: "IncidentTruck",
                newName: "IncidentTrucks");

            migrationBuilder.RenameTable(
                name: "IncidentRoad",
                newName: "IncidentRoads");

            migrationBuilder.RenameTable(
                name: "IncidentDepot",
                newName: "IncidentDepots");

            migrationBuilder.RenameTable(
                name: "IncidentArea",
                newName: "IncidentAreas");

            migrationBuilder.RenameTable(
                name: "AreaCondition",
                newName: "AreaConditions");

            migrationBuilder.RenameIndex(
                name: "IX_UnsafeItem_UnsafeCategoryCode",
                table: "UnsafeItems",
                newName: "IX_UnsafeItems_UnsafeCategoryCode");

            migrationBuilder.RenameIndex(
                name: "IX_PartTwo_InvestigateCardId",
                table: "PartTwos",
                newName: "IX_PartTwos_InvestigateCardId");

            migrationBuilder.RenameIndex(
                name: "IX_PartThree_InvestigateCardId",
                table: "PartThrees",
                newName: "IX_PartThrees_InvestigateCardId");

            migrationBuilder.RenameIndex(
                name: "IX_PartOne_VehicleId",
                table: "PartOnes",
                newName: "IX_PartOnes_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_PartOne_RegionId",
                table: "PartOnes",
                newName: "IX_PartOnes_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_PartOne_EmployeeCode",
                table: "PartOnes",
                newName: "IX_PartOnes_EmployeeCode");

            migrationBuilder.RenameIndex(
                name: "IX_PartOne_BranchCode",
                table: "PartOnes",
                newName: "IX_PartOnes_BranchCode");

            migrationBuilder.RenameIndex(
                name: "IX_PartFour_WeatherId",
                table: "PartFours",
                newName: "IX_PartFours_WeatherId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFour_TrafficId",
                table: "PartFours",
                newName: "IX_PartFours_TrafficId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFour_InvestigateCardId",
                table: "PartFours",
                newName: "IX_PartFours_InvestigateCardId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFour_IncidentTruckPositonId",
                table: "PartFours",
                newName: "IX_PartFours_IncidentTruckPositonId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFour_IncidentTruckId",
                table: "PartFours",
                newName: "IX_PartFours_IncidentTruckId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFour_IncidentRoadId",
                table: "PartFours",
                newName: "IX_PartFours_IncidentRoadId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFour_IncidentDepotId",
                table: "PartFours",
                newName: "IX_PartFours_IncidentDepotId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFour_IncidentAreaId",
                table: "PartFours",
                newName: "IX_PartFours_IncidentAreaId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFour_AreaConditionId",
                table: "PartFours",
                newName: "IX_PartFours_AreaConditionId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFiveDetail_UnsafeItemCode",
                table: "PartFiveDetails",
                newName: "IX_PartFiveDetails_UnsafeItemCode");

            migrationBuilder.RenameIndex(
                name: "IX_PartFiveDetail_UnsafeCategoryCode",
                table: "PartFiveDetails",
                newName: "IX_PartFiveDetails_UnsafeCategoryCode");

            migrationBuilder.RenameIndex(
                name: "IX_PartFiveDetail_PartFiveId",
                table: "PartFiveDetails",
                newName: "IX_PartFiveDetails_PartFiveId");

            migrationBuilder.RenameIndex(
                name: "IX_PartFive_InvestigateCardId",
                table: "PartFives",
                newName: "IX_PartFives_InvestigateCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weathers",
                table: "Weathers",
                column: "WeatherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnsafeItems",
                table: "UnsafeItems",
                column: "UnsafeItemCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnsafeCategories",
                table: "UnsafeCategories",
                column: "UnsafeCategoryCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Traffics",
                table: "Traffics",
                column: "TrafficId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartTwos",
                table: "PartTwos",
                column: "PartTwoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartThrees",
                table: "PartThrees",
                column: "PartThreeId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_PartOnes_InvestigateCardId",
                table: "PartOnes",
                column: "InvestigateCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartOnes",
                table: "PartOnes",
                column: "PartOneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartFours",
                table: "PartFours",
                column: "PartFourId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartFiveDetails",
                table: "PartFiveDetails",
                column: "PartFiveDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PartFives",
                table: "PartFives",
                column: "PartFiveId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvestigateCards",
                table: "InvestigateCards",
                column: "InvestigateCardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentTruckPositons",
                table: "IncidentTruckPositons",
                column: "IncidentTruckPositonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentTrucks",
                table: "IncidentTrucks",
                column: "IncidentTruckId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentRoads",
                table: "IncidentRoads",
                column: "IncidentRoadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentDepots",
                table: "IncidentDepots",
                column: "IncidentDepotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentAreas",
                table: "IncidentAreas",
                column: "IncidentAreaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaConditions",
                table: "AreaConditions",
                column: "AreaConditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestigateCards_PartOnes_InvestigateCardId",
                table: "InvestigateCards",
                column: "InvestigateCardId",
                principalTable: "PartOnes",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFiveDetails_PartFives_PartFiveId",
                table: "PartFiveDetails",
                column: "PartFiveId",
                principalTable: "PartFives",
                principalColumn: "PartFiveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFiveDetails_UnsafeCategories_UnsafeCategoryCode",
                table: "PartFiveDetails",
                column: "UnsafeCategoryCode",
                principalTable: "UnsafeCategories",
                principalColumn: "UnsafeCategoryCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFiveDetails_UnsafeItems_UnsafeItemCode",
                table: "PartFiveDetails",
                column: "UnsafeItemCode",
                principalTable: "UnsafeItems",
                principalColumn: "UnsafeItemCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFives_InvestigateCards_InvestigateCardId",
                table: "PartFives",
                column: "InvestigateCardId",
                principalTable: "InvestigateCards",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFours_AreaConditions_AreaConditionId",
                table: "PartFours",
                column: "AreaConditionId",
                principalTable: "AreaConditions",
                principalColumn: "AreaConditionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFours_IncidentAreas_IncidentAreaId",
                table: "PartFours",
                column: "IncidentAreaId",
                principalTable: "IncidentAreas",
                principalColumn: "IncidentAreaId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_PartFours_IncidentTrucks_IncidentTruckId",
                table: "PartFours",
                column: "IncidentTruckId",
                principalTable: "IncidentTrucks",
                principalColumn: "IncidentTruckId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFours_IncidentTruckPositons_IncidentTruckPositonId",
                table: "PartFours",
                column: "IncidentTruckPositonId",
                principalTable: "IncidentTruckPositons",
                principalColumn: "IncidentTruckPositonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFours_InvestigateCards_InvestigateCardId",
                table: "PartFours",
                column: "InvestigateCardId",
                principalTable: "InvestigateCards",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFours_Traffics_TrafficId",
                table: "PartFours",
                column: "TrafficId",
                principalTable: "Traffics",
                principalColumn: "TrafficId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartFours_Weathers_WeatherId",
                table: "PartFours",
                column: "WeatherId",
                principalTable: "Weathers",
                principalColumn: "WeatherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_Branches_BranchCode",
                table: "PartOnes",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "BranchCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_Employees_EmployeeCode",
                table: "PartOnes",
                column: "EmployeeCode",
                principalTable: "Employees",
                principalColumn: "EmployeeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_Regions_RegionId",
                table: "PartOnes",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOnes_Vehicles_VehicleId",
                table: "PartOnes",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartThrees_InvestigateCards_InvestigateCardId",
                table: "PartThrees",
                column: "InvestigateCardId",
                principalTable: "InvestigateCards",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartTwos_InvestigateCards_InvestigateCardId",
                table: "PartTwos",
                column: "InvestigateCardId",
                principalTable: "InvestigateCards",
                principalColumn: "InvestigateCardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnsafeItems_UnsafeCategories_UnsafeCategoryCode",
                table: "UnsafeItems",
                column: "UnsafeCategoryCode",
                principalTable: "UnsafeCategories",
                principalColumn: "UnsafeCategoryCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
