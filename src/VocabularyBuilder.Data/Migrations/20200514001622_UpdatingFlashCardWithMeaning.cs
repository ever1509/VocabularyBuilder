using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyBuilder.Data.Migrations
{
    public partial class UpdatingFlashCardWithMeaning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCard_Meaning",
                table: "FlashCards");

            migrationBuilder.DropTable(
                name: "Meanings");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_MeaningId",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "MeaningId",
                table: "FlashCards");

            migrationBuilder.AddColumn<string>(
                name: "Meaning",
                table: "FlashCards",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meaning",
                table: "FlashCards");

            migrationBuilder.AddColumn<int>(
                name: "MeaningId",
                table: "FlashCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Meanings",
                columns: table => new
                {
                    MeaningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meanings", x => x.MeaningId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_MeaningId",
                table: "FlashCards",
                column: "MeaningId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCard_Meaning",
                table: "FlashCards",
                column: "MeaningId",
                principalTable: "Meanings",
                principalColumn: "MeaningId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
