using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyBuilder.Data.Migrations
{
    public partial class AddingTypeCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[TypeCards] ([Description]) VALUES ('Daily')");
            migrationBuilder.Sql("INSERT INTO [dbo].[TypeCards] ([Description]) VALUES ('Weekly')");
            migrationBuilder.Sql("INSERT INTO [dbo].[TypeCards] ([Description]) VALUES ('Monthly')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from [dbo].[TypeCards]");
        }
    }
}
