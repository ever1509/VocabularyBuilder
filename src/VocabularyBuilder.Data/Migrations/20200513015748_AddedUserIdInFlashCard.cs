using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyBuilder.Data.Migrations
{
    public partial class AddedUserIdInFlashCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FlashCards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FlashCards");
        }
    }
}
