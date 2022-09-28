using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customerize.Repository.Migrations
{
    public partial class OrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrderStatusId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "Orders");
        }
    }
}
