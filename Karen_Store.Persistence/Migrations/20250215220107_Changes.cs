using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karen_Store.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrowseId",
                table: "Carts",
                newName: "BrowserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "BrowserId",
                table: "Carts",
                newName: "BrowseId");
        }
    }
}
