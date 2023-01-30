using Microsoft.EntityFrameworkCore.Migrations;

namespace Gosto.Migrations
{
    public partial class UpdateColorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Products_ProductId",
                table: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Colors_ProductId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Colors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ProductId",
                table: "Colors",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Products_ProductId",
                table: "Colors",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
