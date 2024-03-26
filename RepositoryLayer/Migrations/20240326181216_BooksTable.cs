using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class BooksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookTable",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(nullable: false),
                    BookAuthor = table.Column<string>(nullable: false),
                    AverageRatings = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    DiscountedPrice = table.Column<int>(nullable: false),
                    BookDescription = table.Column<string>(nullable: true),
                    BookImage = table.Column<string>(nullable: true),
                    BookQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTable", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTable");
        }
    }
}
