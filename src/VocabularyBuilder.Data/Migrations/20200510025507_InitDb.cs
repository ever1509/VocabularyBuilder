using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyBuilder.Data.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Meanings",
                columns: table => new
                {
                    MeaningId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meanings", x => x.MeaningId);
                });

            migrationBuilder.CreateTable(
                name: "TypeCards",
                columns: table => new
                {
                    TypeCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCards", x => x.TypeCardId);
                });

            migrationBuilder.CreateTable(
                name: "FlashCards",
                columns: table => new
                {
                    FlashCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainWord = table.Column<string>(type: "varchar(50)", nullable: true),
                    Example = table.Column<string>(type: "varchar(1000)", nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    FlashCardDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TypeCardId = table.Column<int>(nullable: false),
                    FlashCardPicture = table.Column<byte[]>(nullable: true),
                    MeaningId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCards", x => x.FlashCardId);
                    table.ForeignKey(
                        name: "FK_FlashCard_Category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlashCard_Meaning",
                        column: x => x.MeaningId,
                        principalTable: "Meanings",
                        principalColumn: "MeaningId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlashCard_TypeCard",
                        column: x => x.TypeCardId,
                        principalTable: "TypeCards",
                        principalColumn: "TypeCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_CategoryId",
                table: "FlashCards",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_MeaningId",
                table: "FlashCards",
                column: "MeaningId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_TypeCardId",
                table: "FlashCards",
                column: "TypeCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashCards");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Meanings");

            migrationBuilder.DropTable(
                name: "TypeCards");
        }
    }
}
