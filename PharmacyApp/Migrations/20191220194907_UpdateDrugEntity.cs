using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApp.Migrations
{
    public partial class UpdateDrugEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Users_UserId",
                table: "Drugs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Drugs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelievedSymptom",
                table: "Drugs",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Users_UserId",
                table: "Drugs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Users_UserId",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "RelievedSymptom",
                table: "Drugs");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Drugs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Users_UserId",
                table: "Drugs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
