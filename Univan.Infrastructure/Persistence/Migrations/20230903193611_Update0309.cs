using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univan.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update0309 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "User",
                newName: "Birthdate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "User",
                newName: "Birthday");
        }
    }
}
