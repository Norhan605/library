using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobtask.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumOfCopies = table.Column<int>(type: "int", nullable: false),
                    BorrowersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Borrowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrowers_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BooksBorrowers",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    BorrowersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksBorrowers", x => new { x.BooksId, x.BorrowersId });
                    table.ForeignKey(
                        name: "FK_BooksBorrowers_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksBorrowers_Borrowers_BorrowersId",
                        column: x => x.BorrowersId,
                        principalTable: "Borrowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BorrowersId",
                table: "Books",
                column: "BorrowersId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksBorrowers_BorrowersId",
                table: "BooksBorrowers",
                column: "BorrowersId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowers_BooksId",
                table: "Borrowers",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Borrowers_BorrowersId",
                table: "Books",
                column: "BorrowersId",
                principalTable: "Borrowers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Borrowers_BorrowersId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BooksBorrowers");

            migrationBuilder.DropTable(
                name: "Borrowers");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
