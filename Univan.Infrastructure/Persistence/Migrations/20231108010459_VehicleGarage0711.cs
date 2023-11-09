using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univan.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class VehicleGarage0711 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GaragePlaceId",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GaragePlaceId",
                table: "Vehicle");
        }
    }
}
