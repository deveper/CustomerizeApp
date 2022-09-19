using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customerize.Repository.Migrations
{
    public partial class AdvertisementConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_AppUser_AppUserId",
                table: "Advertisement");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_AppUserId",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Advertisement");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_UserId",
                table: "Advertisement",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_AppUser_UserId",
                table: "Advertisement",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_AppUser_UserId",
                table: "Advertisement");

            migrationBuilder.DropIndex(
                name: "IX_Advertisement_UserId",
                table: "Advertisement");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Advertisement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_AppUserId",
                table: "Advertisement",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_AppUser_AppUserId",
                table: "Advertisement",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
