using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update65 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UnsafeItems",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UnsafeItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "UnsafeItems",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UnsafeItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "UnsafeItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "UnsafeItems",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UnsafeType",
                table: "UnsafeCategories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UnsafeCategories",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UnsafeCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "UnsafeCategories",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UnsafeCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "UnsafeCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "UnsafeCategories",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PartFives",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PartFives",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "PartFives",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PartFives",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "PartFives",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PartFives",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PartFiveDetails",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PartFiveDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "PartFiveDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PartFiveDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "PartFiveDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "PartFiveDetails",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UnsafeItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UnsafeItems");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "UnsafeItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UnsafeItems");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "UnsafeItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "UnsafeItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UnsafeCategories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UnsafeCategories");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "UnsafeCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UnsafeCategories");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "UnsafeCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "UnsafeCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PartFives");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PartFives");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "PartFives");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PartFives");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "PartFives");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PartFives");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PartFiveDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PartFiveDetails");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "PartFiveDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PartFiveDetails");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "PartFiveDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "PartFiveDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UnsafeType",
                table: "UnsafeCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
