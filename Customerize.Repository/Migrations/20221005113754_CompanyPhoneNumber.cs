using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customerize.Repository.Migrations
{
    public partial class CompanyPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyPhoneNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyPhoneNumber",
                table: "Companies");
        }
    }
}
