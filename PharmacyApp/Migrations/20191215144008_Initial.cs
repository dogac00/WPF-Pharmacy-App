using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugFirm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugFirm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    PharmacyInfoId = table.Column<int>(nullable: true),
                    FirmId = table.Column<int>(nullable: true),
                    DrugId = table.Column<int>(nullable: true),
                    PharmacyInfoId1 = table.Column<int>(nullable: true),
                    Vitamin_PharmacyInfoId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Product_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_DrugFirm_FirmId",
                        column: x => x.FirmId,
                        principalTable: "DrugFirm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_PharmacyInfo_PharmacyInfoId1",
                        column: x => x.PharmacyInfoId1,
                        principalTable: "PharmacyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_PharmacyInfo_PharmacyInfoId",
                        column: x => x.PharmacyInfoId,
                        principalTable: "PharmacyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_PharmacyInfo_Vitamin_PharmacyInfoId1",
                        column: x => x.Vitamin_PharmacyInfoId1,
                        principalTable: "PharmacyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PharmacyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_PharmacyInfo_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "PharmacyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdverseEffect",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DrugId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdverseEffect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdverseEffect_Product_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Benefit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    VitaminId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Benefit_Product_VitaminId",
                        column: x => x.VitaminId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Symptom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DrugId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Symptom_Product_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdverseEffect_DrugId",
                table: "AdverseEffect",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefit_VitaminId",
                table: "Benefit",
                column: "VitaminId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DrugId",
                table: "Product",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_FirmId",
                table: "Product",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PharmacyInfoId1",
                table: "Product",
                column: "PharmacyInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Product_PharmacyInfoId",
                table: "Product",
                column: "PharmacyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Vitamin_PharmacyInfoId1",
                table: "Product",
                column: "Vitamin_PharmacyInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Symptom_DrugId",
                table: "Symptom",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PharmacyId",
                table: "Users",
                column: "PharmacyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdverseEffect");

            migrationBuilder.DropTable(
                name: "Benefit");

            migrationBuilder.DropTable(
                name: "Symptom");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "DrugFirm");

            migrationBuilder.DropTable(
                name: "PharmacyInfo");
        }
    }
}
