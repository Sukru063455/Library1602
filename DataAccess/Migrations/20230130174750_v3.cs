using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookWriters_WriterId",
                table: "BookWriters");

            migrationBuilder.CreateIndex(
                name: "IX_BookWriters_WriterId",
                table: "BookWriters",
                column: "WriterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookWriters_WriterId",
                table: "BookWriters");

            migrationBuilder.CreateIndex(
                name: "IX_BookWriters_WriterId",
                table: "BookWriters",
                column: "WriterId",
                unique: true);
        }
    }
}
