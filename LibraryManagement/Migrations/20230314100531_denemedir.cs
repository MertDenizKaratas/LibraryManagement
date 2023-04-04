using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class denemedir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Books_BookItemId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderMaster_Students_StudentId",
                table: "OrderMaster");

            migrationBuilder.DropIndex(
                name: "IX_OrderMaster_StudentId",
                table: "OrderMaster");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_BookItemId",
                table: "OrderDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderMaster_StudentId",
                table: "OrderMaster",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_BookItemId",
                table: "OrderDetail",
                column: "BookItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Books_BookItemId",
                table: "OrderDetail",
                column: "BookItemId",
                principalTable: "Books",
                principalColumn: "BookItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderMaster_Students_StudentId",
                table: "OrderMaster",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
