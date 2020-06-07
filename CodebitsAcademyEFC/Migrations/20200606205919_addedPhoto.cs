using Microsoft.EntityFrameworkCore.Migrations;

namespace CodebitsAcademyEFC.Migrations
{
    public partial class addedPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "EmployeesTable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "EmployeesTable");
        }
    }
}
