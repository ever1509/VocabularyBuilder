using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyBuilder.Data.Migrations
{
    public partial class UpdatingRelationshipDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCard_Category",
                table: "FlashCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCard_Meaning",
                table: "FlashCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCard_TypeCard",
                table: "FlashCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlashCards",
                table: "FlashCards");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_CategoryId",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "FlashCardId",
                table: "FlashCards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlashCards",
                table: "FlashCards",
                columns: new[] { "CategoryId", "TypeCardId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCard_Category",
                table: "FlashCards",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCard_Meaning",
                table: "FlashCards",
                column: "MeaningId",
                principalTable: "Meanings",
                principalColumn: "MeaningId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCard_TypeCard",
                table: "FlashCards",
                column: "TypeCardId",
                principalTable: "TypeCards",
                principalColumn: "TypeCardId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCard_Category",
                table: "FlashCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCard_Meaning",
                table: "FlashCards");

            migrationBuilder.DropForeignKey(
                name: "FK_FlashCard_TypeCard",
                table: "FlashCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlashCards",
                table: "FlashCards");

            migrationBuilder.AddColumn<int>(
                name: "FlashCardId",
                table: "FlashCards",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlashCards",
                table: "FlashCards",
                column: "FlashCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_CategoryId",
                table: "FlashCards",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCard_Category",
                table: "FlashCards",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCard_Meaning",
                table: "FlashCards",
                column: "MeaningId",
                principalTable: "Meanings",
                principalColumn: "MeaningId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCard_TypeCard",
                table: "FlashCards",
                column: "TypeCardId",
                principalTable: "TypeCards",
                principalColumn: "TypeCardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
