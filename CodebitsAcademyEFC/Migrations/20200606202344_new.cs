using Microsoft.EntityFrameworkCore.Migrations;

namespace CodebitsAcademyEFC.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "SystemUsersTable",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SystemUsersTable",
                newName: "ID");
        }
    }
}
