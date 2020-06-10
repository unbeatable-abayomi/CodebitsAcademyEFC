using Microsoft.EntityFrameworkCore.Migrations;

namespace CodebitsAcademyEFC.Migrations
{
    public partial class addedDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeparmentId",
                table: "EmployeesTable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "EmployeesTable",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTable_DepartmentID",
                table: "EmployeesTable",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesTable_DepartmentsTable_DepartmentID",
                table: "EmployeesTable",
                column: "DepartmentID",
                principalTable: "DepartmentsTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesTable_DepartmentsTable_DepartmentID",
                table: "EmployeesTable");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesTable_DepartmentID",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "DeparmentId",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "EmployeesTable");
        }
    }
}
