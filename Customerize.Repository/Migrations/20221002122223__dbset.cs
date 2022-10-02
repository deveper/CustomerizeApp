using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customerize.Repository.Migrations
{
    public partial class _dbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_AppUser_UserId",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDocument_Products_ProductId",
                table: "ProductDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDocument",
                table: "ProductDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisement",
                table: "Advertisement");

            migrationBuilder.RenameTable(
                name: "ProductDocument",
                newName: "ProductDocuments");

            migrationBuilder.RenameTable(
                name: "Advertisement",
                newName: "Advertisements");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDocument_ProductId",
                table: "ProductDocuments",
                newName: "IX_ProductDocuments_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_UserId",
                table: "Advertisements",
                newName: "IX_Advertisements_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDocuments",
                table: "ProductDocuments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_AppUser_UserId",
                table: "Advertisements",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDocuments_Products_ProductId",
                table: "ProductDocuments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_AppUser_UserId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDocuments_Products_ProductId",
                table: "ProductDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDocuments",
                table: "ProductDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements");

            migrationBuilder.RenameTable(
                name: "ProductDocuments",
                newName: "ProductDocument");

            migrationBuilder.RenameTable(
                name: "Advertisements",
                newName: "Advertisement");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDocuments_ProductId",
                table: "ProductDocument",
                newName: "IX_ProductDocument_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisements_UserId",
                table: "Advertisement",
                newName: "IX_Advertisement_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDocument",
                table: "ProductDocument",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisement",
                table: "Advertisement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_AppUser_UserId",
                table: "Advertisement",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDocument_Products_ProductId",
                table: "ProductDocument",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
