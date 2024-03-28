using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class CartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyCartTable",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCartTable", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_MyCartTable_BookTable_BookId",
                        column: x => x.BookId,
                        principalTable: "BookTable",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyCartTable_usersTable_UserId",
                        column: x => x.UserId,
                        principalTable: "usersTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyCartTable_BookId",
                table: "MyCartTable",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_MyCartTable_UserId",
                table: "MyCartTable",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyCartTable");
        }
    }
}
