using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartFives",
                columns: table => new
                {
                    PartFiveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestigateCardId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartFives", x => x.PartFiveId);
                    table.ForeignKey(
                        name: "FK_PartFives_InvestigateCards_InvestigateCardId",
                        column: x => x.InvestigateCardId,
                        principalTable: "InvestigateCards",
                        principalColumn: "InvestigateCardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnsafeCategories",
                columns: table => new
                {
                    UnsafeCategoryCode = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    UnsafeType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnsafeCategories", x => x.UnsafeCategoryCode);
                });

            migrationBuilder.CreateTable(
                name: "UnsafeItems",
                columns: table => new
                {
                    UnsafeItemCode = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    UnsafeCategoryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnsafeItems", x => x.UnsafeItemCode);
                    table.ForeignKey(
                        name: "FK_UnsafeItems_UnsafeCategories_UnsafeCategoryCode",
                        column: x => x.UnsafeCategoryCode,
                        principalTable: "UnsafeCategories",
                        principalColumn: "UnsafeCategoryCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PartFiveDetails",
                columns: table => new
                {
                    PartFiveDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartFiveId = table.Column<int>(nullable: false),
                    UnsafeCategoryCode = table.Column<string>(maxLength: 3, nullable: false),
                    UnsafeItemCode = table.Column<string>(maxLength: 3, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartFiveDetails", x => x.PartFiveDetailId);
                    table.ForeignKey(
                        name: "FK_PartFiveDetails_PartFives_PartFiveId",
                        column: x => x.PartFiveId,
                        principalTable: "PartFives",
                        principalColumn: "PartFiveId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartFiveDetails_UnsafeCategories_UnsafeCategoryCode",
                        column: x => x.UnsafeCategoryCode,
                        principalTable: "UnsafeCategories",
                        principalColumn: "UnsafeCategoryCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartFiveDetails_UnsafeItems_UnsafeItemCode",
                        column: x => x.UnsafeItemCode,
                        principalTable: "UnsafeItems",
                        principalColumn: "UnsafeItemCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartFiveDetails_PartFiveId",
                table: "PartFiveDetails",
                column: "PartFiveId");

            migrationBuilder.CreateIndex(
                name: "IX_PartFiveDetails_UnsafeCategoryCode",
                table: "PartFiveDetails",
                column: "UnsafeCategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_PartFiveDetails_UnsafeItemCode",
                table: "PartFiveDetails",
                column: "UnsafeItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_PartFives_InvestigateCardId",
                table: "PartFives",
                column: "InvestigateCardId");

            migrationBuilder.CreateIndex(
                name: "IX_UnsafeItems_UnsafeCategoryCode",
                table: "UnsafeItems",
                column: "UnsafeCategoryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartFiveDetails");

            migrationBuilder.DropTable(
                name: "PartFives");

            migrationBuilder.DropTable(
                name: "UnsafeItems");

            migrationBuilder.DropTable(
                name: "UnsafeCategories");
        }
    }
}
