using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace STQAPWEB.Migrations
{
    /// <inheritdoc />
    public partial class AddStudetentTeacherColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isStudent",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isTeacher",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isStudent",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isTeacher",
                table: "Users");
        }
    }
}
