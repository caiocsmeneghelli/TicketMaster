using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketMaster.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddActivePropertyMovieSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "MovieSessions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "MovieSessions");
        }
    }
}
