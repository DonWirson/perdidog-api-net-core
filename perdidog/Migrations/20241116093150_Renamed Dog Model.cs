using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace perdidog.Migrations
{
    /// <inheritdoc />
    public partial class RenamedDogModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_AnimalTypes_AnimalTypeId",
                table: "Dog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dog",
                table: "Dog");

            migrationBuilder.RenameTable(
                name: "Dog",
                newName: "LostPet");

            migrationBuilder.RenameIndex(
                name: "IX_Dog_AnimalTypeId",
                table: "LostPet",
                newName: "IX_LostPet_AnimalTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LostPet",
                table: "LostPet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LostPet_AnimalTypes_AnimalTypeId",
                table: "LostPet",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LostPet_AnimalTypes_AnimalTypeId",
                table: "LostPet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LostPet",
                table: "LostPet");

            migrationBuilder.RenameTable(
                name: "LostPet",
                newName: "Dog");

            migrationBuilder.RenameIndex(
                name: "IX_LostPet_AnimalTypeId",
                table: "Dog",
                newName: "IX_Dog_AnimalTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dog",
                table: "Dog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_AnimalTypes_AnimalTypeId",
                table: "Dog",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
