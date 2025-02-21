using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CinemaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

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

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    IdRoom = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.IdRoom);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "MovieCategories",
                columns: table => new
                {
                    IdMovie = table.Column<int>(type: "integer", nullable: false),
                    IdCategory = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategories", x => new { x.IdMovie, x.IdCategory });
                    table.ForeignKey(
                        name: "FK_MovieCategories_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCategories_Movies_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movies",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieSession",
                columns: table => new
                {
                    IdMovieSession = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMovie = table.Column<int>(type: "integer", nullable: false),
                    IdRoom = table.Column<int>(type: "integer", nullable: false),
                    SessionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSession", x => x.IdMovieSession);
                    table.ForeignKey(
                        name: "FK_MovieSession_Movies_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Movies",
                        principalColumn: "IdMovie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSession_Rooms_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Rooms",
                        principalColumn: "IdRoom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    IdSeat = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdRoom = table.Column<int>(type: "integer", nullable: false),
                    RowLetter = table.Column<string>(type: "text", nullable: false),
                    SeatNumber = table.Column<int>(type: "integer", nullable: false),
                    TypeSeat = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.IdSeat);
                    table.ForeignKey(
                        name: "FK_Seats_Rooms_IdRoom",
                        column: x => x.IdRoom,
                        principalTable: "Rooms",
                        principalColumn: "IdRoom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    IdTicket = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSeat = table.Column<int>(type: "integer", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    IdMovieSession = table.Column<int>(type: "integer", nullable: false),
                    TypeTicket = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_Ticket_MovieSession_IdMovieSession",
                        column: x => x.IdMovieSession,
                        principalTable: "MovieSession",
                        principalColumn: "IdMovieSession",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Seats_IdSeat",
                        column: x => x.IdSeat,
                        principalTable: "Seats",
                        principalColumn: "IdSeat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategories_IdCategory",
                table: "MovieCategories",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSession_IdMovie",
                table: "MovieSession",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSession_IdRoom",
                table: "MovieSession",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_IdRoom",
                table: "Seats",
                column: "IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdMovieSession",
                table: "Ticket",
                column: "IdMovieSession");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdSeat",
                table: "Ticket",
                column: "IdSeat");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdUser",
                table: "Ticket",
                column: "IdUser");

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
            migrationBuilder.DropTable(
                name: "MovieCategories");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "MovieSession");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
