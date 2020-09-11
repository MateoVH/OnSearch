using Microsoft.EntityFrameworkCore.Migrations;

namespace OnSearch.Web.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStarred",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStarred",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }
    }
}
