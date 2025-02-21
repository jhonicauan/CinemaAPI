using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class MovieAdd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "pk_user",
                table: "Users",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "pk_user",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "username",
                table: "Users");
        }
    }
}
