using Microsoft.EntityFrameworkCore.Migrations;

namespace Pencil42App.Web.Migrations
{
    public partial class SuggestionKindAddSuggestionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kind",
                table: "Suggestion",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kind",
                table: "Suggestion");
        }
    }
}
