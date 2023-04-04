using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookItemName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookItemId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "OrderMaster",
                columns: table => new
                {
                    OrderMasterId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    BMethod = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    GTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMaster", x => x.OrderMasterId);
                    table.ForeignKey(
                        name: "FK_OrderMaster_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderMasterId = table.Column<long>(type: "bigint", nullable: false),
                    BookItemId = table.Column<int>(type: "int", nullable: false),
                    BookItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Books_BookItemId",
                        column: x => x.BookItemId,
                        principalTable: "Books",
                        principalColumn: "BookItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_OrderMaster_OrderMasterId",
                        column: x => x.OrderMasterId,
                        principalTable: "OrderMaster",
                        principalColumn: "OrderMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_BookItemId",
                table: "OrderDetail",
                column: "BookItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderMasterId",
                table: "OrderDetail",
                column: "OrderMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMaster_StudentId",
                table: "OrderMaster",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "OrderMaster");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
