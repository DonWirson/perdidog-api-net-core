using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace perdidog.Migrations
{
    /// <inheritdoc />
    public partial class Addedlostpetseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LostPet",
                columns: new[] { "Id", "AnimalTypeId", "GenderId", "IsActive", "Name", "ReportDate" },
                values: new object[,]
                {
                    { new Guid("22e71034-37e2-44ad-b31e-928b1f431d45"), new Guid("64d6b2f4-77a3-46d8-91be-fc36ab0103b9"), 1, true, "Lucky", new DateTime(2024, 12, 20, 1, 4, 45, 635, DateTimeKind.Local).AddTicks(8402) },
                    { new Guid("8b06fc47-666f-4685-8ec0-d5793b9be883"), new Guid("e1f95dcb-0103-47f6-9ddb-dad7dae65365"), 1, true, "", new DateTime(2024, 12, 20, 1, 4, 45, 635, DateTimeKind.Local).AddTicks(8405) },
                    { new Guid("8b5849f8-554b-4057-bb90-9ba29aba9a1a"), new Guid("64d6b2f4-77a3-46d8-91be-fc36ab0103b9"), 1, true, "Cabezon", new DateTime(2024, 12, 20, 1, 4, 45, 635, DateTimeKind.Local).AddTicks(8336) },
                    { new Guid("dfae5930-af55-4aa3-8c11-f141fd75ce69"), new Guid("64d6b2f4-77a3-46d8-91be-fc36ab0103b9"), 2, true, "Cabezona", new DateTime(2024, 12, 20, 1, 4, 45, 635, DateTimeKind.Local).AddTicks(8399) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: new Guid("22e71034-37e2-44ad-b31e-928b1f431d45"));

            migrationBuilder.DeleteData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: new Guid("8b06fc47-666f-4685-8ec0-d5793b9be883"));

            migrationBuilder.DeleteData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: new Guid("8b5849f8-554b-4057-bb90-9ba29aba9a1a"));

            migrationBuilder.DeleteData(
                table: "LostPet",
                keyColumn: "Id",
                keyValue: new Guid("dfae5930-af55-4aa3-8c11-f141fd75ce69"));
        }
    }
}
