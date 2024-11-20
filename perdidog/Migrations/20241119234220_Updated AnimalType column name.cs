using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace perdidog.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAnimalTypecolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnimalName",
                table: "AnimalTypes",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AnimalTypes",
                newName: "AnimalName");
        }
    }
}
