using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddingDataFromCategories : Migration
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
