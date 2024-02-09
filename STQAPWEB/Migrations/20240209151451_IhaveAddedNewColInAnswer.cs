using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STQAPWEB.Migrations
{
    /// <inheritdoc />
    public partial class IhaveAddedNewColInAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Answers");
        }
    }
}
