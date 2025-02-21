using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CinemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class MovieAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "pk_users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "username",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    IdMovie = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.IdMovie);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.CreateIndex(
                name: "pk_users",
                table: "Users",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "username",
                table: "Users",
                column: "Username",
                unique: true);
        }
    }
}
