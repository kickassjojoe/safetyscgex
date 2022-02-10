using Microsoft.EntityFrameworkCore.Migrations;

namespace VK1.SCGE.Safety.Services.Migrations
{
    public partial class update01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeCode = table.Column<string>(maxLength: 11, nullable: false),
                    NameTH = table.Column<string>(maxLength: 100, nullable: true),
                    NameEN = table.Column<string>(maxLength: 100, nullable: true),
                    Position = table.Column<string>(maxLength: 100, nullable: true),
                    BusinessUnitLevel2 = table.Column<string>(maxLength: 100, nullable: true),
                    BusinessUnitLevel3 = table.Column<string>(maxLength: 100, nullable: true),
                    BusinessUnitLevel4 = table.Column<string>(maxLength: 100, nullable: true),
                    BusinessUnitLevel5 = table.Column<string>(maxLength: 100, nullable: true),
                    BusinessUnitLevel6 = table.Column<string>(maxLength: 100, nullable: true),
                    Division = table.Column<string>(maxLength: 100, nullable: true),
                    Branch = table.Column<string>(maxLength: 100, nullable: true),
                    BranchCode = table.Column<string>(maxLength: 100, nullable: true),
                    BranchName = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    SupervisorCode = table.Column<string>(maxLength: 100, nullable: true),
                    SupervisorEmail = table.Column<string>(maxLength: 100, nullable: true),
                    SupervisorPosition = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
