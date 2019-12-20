using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApp.Migrations
{
    public partial class NavigationPropertiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Symptoms_DrugId",
                table: "Symptoms");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_DrugId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_AdverseEffects_DrugId",
                table: "AdverseEffects");

            migrationBuilder.AddColumn<int>(
                name: "AdverseEffectId",
                table: "Drugs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Drugs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SymptomId",
                table: "Drugs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_DrugId",
                table: "Symptoms",
                column: "DrugId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DrugId",
                table: "Ingredients",
                column: "DrugId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdverseEffects_DrugId",
                table: "AdverseEffects",
                column: "DrugId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Symptoms_DrugId",
                table: "Symptoms");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_DrugId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_AdverseEffects_DrugId",
                table: "AdverseEffects");

            migrationBuilder.DropColumn(
                name: "AdverseEffectId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "SymptomId",
                table: "Drugs");

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_DrugId",
                table: "Symptoms",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DrugId",
                table: "Ingredients",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_AdverseEffects_DrugId",
                table: "AdverseEffects",
                column: "DrugId");
        }
    }
}
