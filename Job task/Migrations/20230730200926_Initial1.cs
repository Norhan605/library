using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobtask.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Borrowers_BorrowersId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BorrowersId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BorrowersId",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorrowersId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BorrowersId",
                table: "Books",
                column: "BorrowersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Borrowers_BorrowersId",
                table: "Books",
                column: "BorrowersId",
                principalTable: "Borrowers",
                principalColumn: "Id");
        }
    }
}
