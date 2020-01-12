using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SallesWebMvc.Migrations
{
    public partial class anothers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BithDate",
                table: "Seller");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Seller",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Seller");

            migrationBuilder.AddColumn<DateTime>(
                name: "BithDate",
                table: "Seller",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
