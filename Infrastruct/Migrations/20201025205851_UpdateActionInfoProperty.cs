using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateActionInfoProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionName",
                table: "Actions");

            migrationBuilder.AddColumn<string>(
                name: "ActionInfo",
                table: "Actions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionInfo",
                table: "Actions");

            migrationBuilder.AddColumn<string>(
                name: "ActionName",
                table: "Actions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
