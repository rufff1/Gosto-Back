using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gosto.Migrations
{
    public partial class CreatedTrendTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreateTrends",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatAt = table.Column<DateTime>(nullable: true),
                    CreatBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    BackImage = table.Column<string>(maxLength: 150, nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateTrends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OurTeamBackImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatAt = table.Column<DateTime>(nullable: true),
                    CreatBy = table.Column<string>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    UpdateBy = table.Column<string>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    Image = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurTeamBackImages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateTrends");

            migrationBuilder.DropTable(
                name: "OurTeamBackImages");
        }
    }
}
