using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace perdidog.Migrations
{
    /// <inheritdoc />
    public partial class AddedAnimalTypeseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AnimalTypes",
                columns: new[] { "Id", "AnimalName" },
                values: new object[,]
                {
                    { new Guid("64d6b2f4-77a3-46d8-91be-fc36ab0103b9"), "Dog" },
                    { new Guid("b8851d86-8193-48a5-9561-458b82b16f1e"), "Snake" },
                    { new Guid("e1f95dcb-0103-47f6-9ddb-dad7dae65365"), "Cat" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: new Guid("64d6b2f4-77a3-46d8-91be-fc36ab0103b9"));

            migrationBuilder.DeleteData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: new Guid("b8851d86-8193-48a5-9561-458b82b16f1e"));

            migrationBuilder.DeleteData(
                table: "AnimalTypes",
                keyColumn: "Id",
                keyValue: new Guid("e1f95dcb-0103-47f6-9ddb-dad7dae65365"));
        }
    }
}
