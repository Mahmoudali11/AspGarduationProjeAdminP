using Microsoft.EntityFrameworkCore.Migrations;

namespace AspGraduateProjAdminPan.Migrations
{
    public partial class editemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Emp",
                newName: "HireDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HireDate",
                table: "Emp",
                newName: "MyProperty");
        }
    }
}
