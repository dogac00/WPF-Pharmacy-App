using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApp.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Users_UserId",
                table: "Drugs");

            migrationBuilder.DropTable(
                name: "AdverseEffects");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropColumn(
                name: "AdverseEffectId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "SymptomId",
                table: "Drugs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Drugs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AdverseEffect",
                table: "Drugs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredient",
                table: "Drugs",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Users_UserId",
                table: "Drugs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Users_UserId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "AdverseEffect",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Ingredient",
                table: "Drugs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Drugs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdverseEffectId",
                table: "Drugs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Drugs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SymptomId",
                table: "Drugs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdverseEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdverseEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdverseEffects_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Symptoms_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdverseEffects_DrugId",
                table: "AdverseEffects",
                column: "DrugId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DrugId",
                table: "Ingredients",
                column: "DrugId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_DrugId",
                table: "Symptoms",
                column: "DrugId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Users_UserId",
                table: "Drugs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
