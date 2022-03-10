using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customerize.Repository.Migrations
{
    public partial class AppUserConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Companies_CompanyId",
                table: "AppUser");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Companies_CompanyId",
                table: "AppUser",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Companies_CompanyId",
                table: "AppUser");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Companies_CompanyId",
                table: "AppUser",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
