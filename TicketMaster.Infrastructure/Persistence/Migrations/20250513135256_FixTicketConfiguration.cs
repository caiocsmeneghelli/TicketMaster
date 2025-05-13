using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMaster.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixTicketConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_MovieSessions_GuidMovieSession",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_MovieSessions_MovieSessionGuid",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_GuidMovieSession",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_MovieSessionGuid",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "MovieSessionGuid",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_GuidMovieSession",
                table: "Tickets",
                column: "GuidMovieSession");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_MovieSessions_GuidMovieSession",
                table: "Tickets",
                column: "GuidMovieSession",
                principalTable: "MovieSessions",
                principalColumn: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_MovieSessions_GuidMovieSession",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_GuidMovieSession",
                table: "Tickets");

            migrationBuilder.AddColumn<Guid>(
                name: "MovieSessionGuid",
                table: "Tickets",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_GuidMovieSession",
                table: "Tickets",
                column: "GuidMovieSession",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_MovieSessionGuid",
                table: "Tickets",
                column: "MovieSessionGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_MovieSessions_GuidMovieSession",
                table: "Tickets",
                column: "GuidMovieSession",
                principalTable: "MovieSessions",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_MovieSessions_MovieSessionGuid",
                table: "Tickets",
                column: "MovieSessionGuid",
                principalTable: "MovieSessions",
                principalColumn: "Guid");
        }
    }
}
