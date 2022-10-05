using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customerize.Repository.Migrations
{
    public partial class OrderContactMail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactMail",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactMail",
                table: "Orders");
        }
    }
}
