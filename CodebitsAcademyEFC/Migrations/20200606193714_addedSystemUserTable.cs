using Microsoft.EntityFrameworkCore.Migrations;

namespace CodebitsAcademyEFC.Migrations
{
    public partial class addedSystemUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "EmployeesTable",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "SystemUsersTable",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 5, nullable: false),
                    Password = table.Column<string>(maxLength: 5, nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsersTable", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemUsersTable");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EmployeesTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
