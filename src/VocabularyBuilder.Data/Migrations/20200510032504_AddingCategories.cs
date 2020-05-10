using Microsoft.EntityFrameworkCore.Migrations;

namespace VocabularyBuilder.Data.Migrations
{
    public partial class AddingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Categories] ([Description]) VALUES('Animals')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Categories] ([Description]) VALUES('Body Parts')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Categories] ([Description]) VALUES('Clothes')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Categories] ([Description]) VALUES('Education')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Categories] ([Description]) VALUES('Family')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Categories] ([Description]) VALUES('Food')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Categories] ([Description]) VALUES('Business')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from [dbo].[Categories]");
        }
    }
}
