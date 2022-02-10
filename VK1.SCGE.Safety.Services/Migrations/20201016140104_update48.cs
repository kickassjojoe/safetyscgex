using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update48 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "PartTwos");

            migrationBuilder.DropColumn(
                name: "ProductValue",
                table: "PartTwos");

            migrationBuilder.AddColumn<bool>(
                name: "IsProductDamage",
                table: "PartTwos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductDamageQty",
                table: "PartTwos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductDamageValue",
                table: "PartTwos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductQty",
                table: "PartTwos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProductDamage",
                table: "PartTwos");

            migrationBuilder.DropColumn(
                name: "ProductDamageQty",
                table: "PartTwos");

            migrationBuilder.DropColumn(
                name: "ProductDamageValue",
                table: "PartTwos");

            migrationBuilder.DropColumn(
                name: "ProductQty",
                table: "PartTwos");

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "PartTwos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductValue",
                table: "PartTwos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
