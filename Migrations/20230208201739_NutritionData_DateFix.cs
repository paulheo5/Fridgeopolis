using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fridgeopolis.Migrations
{
    /// <inheritdoc />
    public partial class NutritionDataDateFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "NutritionData",
                newName: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "NutritionData",
                newName: "Date");
        }
    }
}
