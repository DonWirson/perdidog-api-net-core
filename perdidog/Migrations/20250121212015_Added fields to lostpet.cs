using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace perdidog.Migrations
{
    /// <inheritdoc />
    public partial class Addedfieldstolostpet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LostPet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistinctFeature",
                table: "LostPet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "LostPet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumberInscribed",
                table: "LostPet",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "DistinctFeature", "ImageUrl", "PhoneNumberInscribed", "ReportDate" },
                values: new object[] { null, null, null, null, new DateTime(2025, 1, 21, 18, 20, 14, 542, DateTimeKind.Local).AddTicks(6592) });

            migrationBuilder.UpdateData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "DistinctFeature", "ImageUrl", "PhoneNumberInscribed", "ReportDate" },
                values: new object[] { null, null, null, null, new DateTime(2025, 1, 21, 18, 20, 14, 542, DateTimeKind.Local).AddTicks(6674) });

            migrationBuilder.UpdateData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "DistinctFeature", "ImageUrl", "PhoneNumberInscribed", "ReportDate" },
                values: new object[] { null, null, null, null, new DateTime(2025, 1, 21, 18, 20, 14, 542, DateTimeKind.Local).AddTicks(6677) });

            migrationBuilder.UpdateData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "DistinctFeature", "ImageUrl", "PhoneNumberInscribed", "ReportDate" },
                values: new object[] { null, null, null, null, new DateTime(2025, 1, 21, 18, 20, 14, 542, DateTimeKind.Local).AddTicks(6681) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "LostPet");

            migrationBuilder.DropColumn(
                name: "DistinctFeature",
                table: "LostPet");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "LostPet");

            migrationBuilder.DropColumn(
                name: "PhoneNumberInscribed",
                table: "LostPet");

            migrationBuilder.UpdateData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReportDate",
                value: new DateTime(2025, 1, 8, 2, 33, 34, 149, DateTimeKind.Local).AddTicks(2783));

            migrationBuilder.UpdateData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReportDate",
                value: new DateTime(2025, 1, 8, 2, 33, 34, 149, DateTimeKind.Local).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReportDate",
                value: new DateTime(2025, 1, 8, 2, 33, 34, 149, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReportDate",
                value: new DateTime(2025, 1, 8, 2, 33, 34, 149, DateTimeKind.Local).AddTicks(2848));
        }
    }
}
