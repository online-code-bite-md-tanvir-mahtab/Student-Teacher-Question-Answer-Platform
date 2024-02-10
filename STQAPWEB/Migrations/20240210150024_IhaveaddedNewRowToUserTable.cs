using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STQAPWEB.Migrations
{
    /// <inheritdoc />
    public partial class IhaveaddedNewRowToUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isModerator",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isModerator",
                table: "Users");
        }
    }
}
