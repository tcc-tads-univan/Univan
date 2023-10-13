using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univan.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StudentAddres1310 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompleteLineAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GooglePlaceId = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_AddressId",
                table: "Student",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Address_AddressId",
                table: "Student",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Address_AddressId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Student_AddressId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Student");
        }
    }
}
