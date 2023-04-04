using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GTotal",
                table: "OrderMaster");

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "OrderMaster",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "OrderMaster");

            migrationBuilder.AddColumn<decimal>(
                name: "GTotal",
                table: "OrderMaster",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
