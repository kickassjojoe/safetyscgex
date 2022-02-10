using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update73 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PartSix",
                columns: table => new
                {
                    PartSixId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    InvestigateCardId = table.Column<Guid>(nullable: false),
                    UnsafeItemCode = table.Column<string>(maxLength: 3, nullable: true),
                    UnsafeItemName = table.Column<string>(maxLength: 150, nullable: true),
                    Solution = table.Column<string>(maxLength: 500, nullable: true),
                    ResponsePerson = table.Column<string>(maxLength: 150, nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartSix", x => x.PartSixId);
                    table.ForeignKey(
                        name: "FK_PartSix_InvestigateCards_InvestigateCardId",
                        column: x => x.InvestigateCardId,
                        principalTable: "InvestigateCards",
                        principalColumn: "InvestigateCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartSix_InvestigateCardId",
                table: "PartSix",
                column: "InvestigateCardId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartSix");
        }
    }
}
