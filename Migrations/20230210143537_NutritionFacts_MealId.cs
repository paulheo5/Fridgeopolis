using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renipe.Migrations
{
    /// <inheritdoc />
    public partial class NutritionFactsMealId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nutrition_id",
                table: "NutritionData",
                newName: "meal_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "meal_id",
                table: "NutritionData",
                newName: "nutrition_id");
        }
    }
}
