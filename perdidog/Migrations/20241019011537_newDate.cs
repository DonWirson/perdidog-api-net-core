using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace perdidog.Migrations
{
    /// <inheritdoc />
    public partial class newDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Dog");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportDate",
                table: "Dog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportDate",
                table: "Dog");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Dog",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
