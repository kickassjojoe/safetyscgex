using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update72 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvestigateStatusCode",
                table: "InvestigateCards",
                maxLength: 3,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvestigateStatuses",
                columns: table => new
                {
                    InvestigateStatusCode = table.Column<string>(maxLength: 3, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 150, nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestigateStatuses", x => x.InvestigateStatusCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvestigateCards_InvestigateStatusCode",
                table: "InvestigateCards",
                column: "InvestigateStatusCode");

            migrationBuilder.AddForeignKey(
                name: "FK_InvestigateCards_InvestigateStatuses_InvestigateStatusCode",
                table: "InvestigateCards",
                column: "InvestigateStatusCode",
                principalTable: "InvestigateStatuses",
                principalColumn: "InvestigateStatusCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvestigateCards_InvestigateStatuses_InvestigateStatusCode",
                table: "InvestigateCards");

            migrationBuilder.DropTable(
                name: "InvestigateStatuses");

            migrationBuilder.DropIndex(
                name: "IX_InvestigateCards_InvestigateStatusCode",
                table: "InvestigateCards");

            migrationBuilder.DropColumn(
                name: "InvestigateStatusCode",
                table: "InvestigateCards");
        }
    }
}
