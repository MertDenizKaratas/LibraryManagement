using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class deneme3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GivenName",
                table: "Users",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Users",
                newName: "GivenName");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Users",
                newName: "Id");
        }
    }
}
