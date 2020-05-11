using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyBuilder.Data.Migrations
{
    public partial class UpdatingFlashCardTableWithId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FlashCards",
                table: "FlashCards");

            migrationBuilder.AddColumn<int>(
                name: "FlashCardId",
                table: "FlashCards",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
