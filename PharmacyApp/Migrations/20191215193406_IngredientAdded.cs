using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApp.Migrations
{
    public partial class IngredientAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_IngredientId",
                table: "Product",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Ingredient_IngredientId",
                table: "Product",
                column: "IngredientId",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Ingredient_IngredientId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Product_IngredientId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Product");
        }
    }
}
