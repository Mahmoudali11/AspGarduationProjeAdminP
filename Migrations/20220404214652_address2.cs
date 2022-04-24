using Microsoft.EntityFrameworkCore.Migrations;

namespace AspGraduateProjAdminPan.Migrations
{
    public partial class address2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CounryId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_CounryId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CounryId",
                table: "City");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_City_CountryId",
                table: "City");

            migrationBuilder.AddColumn<int>(
                name: "CounryId",
                table: "City",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_City_CounryId",
                table: "City",
                column: "CounryId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CounryId",
                table: "City",
                column: "CounryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
