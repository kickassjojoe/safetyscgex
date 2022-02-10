using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckInspectionCategories",
                columns: table => new
                {
                    TruckInspectionCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckInspectionCategories", x => x.TruckInspectionCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TruckInspectionItems",
                columns: table => new
                {
                    TruckInspectionItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    TruckInspectionCategoryId = table.Column<int>(nullable: true),
                    IsMust = table.Column<bool>(nullable: false),
                    IsFirstAndFifteenth = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckInspectionItems", x => x.TruckInspectionItemId);
                    table.ForeignKey(
                        name: "FK_TruckInspectionItems_TruckInspectionCategories_TruckInspectionCategoryId",
                        column: x => x.TruckInspectionCategoryId,
                        principalTable: "TruckInspectionCategories",
                        principalColumn: "TruckInspectionCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TruckInspectionItems_TruckInspectionCategoryId",
                table: "TruckInspectionItems",
                column: "TruckInspectionCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TruckInspectionItems");

            migrationBuilder.DropTable(
                name: "TruckInspectionCategories");
        }
    }
}
