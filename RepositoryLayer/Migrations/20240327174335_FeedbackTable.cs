using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class FeedbackTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedbackTable",
                columns: table => new
                {
                    FeedBackID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CustomerRatings = table.Column<float>(nullable: false),
                    CustomerFeedback = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackTable", x => x.FeedBackID);
                    table.ForeignKey(
                        name: "FK_FeedbackTable_BookTable_BookId",
                        column: x => x.BookId,
                        principalTable: "BookTable",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedbackTable_usersTable_UserId",
                        column: x => x.UserId,
                        principalTable: "usersTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackTable_BookId",
                table: "FeedbackTable",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackTable_UserId",
                table: "FeedbackTable",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackTable");
        }
    }
}
