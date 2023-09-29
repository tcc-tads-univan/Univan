using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univan.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class subscriptionFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionHistory",
                table: "SubscriptionHistory");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionHistoryId",
                table: "SubscriptionHistory",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionHistory",
                table: "SubscriptionHistory",
                column: "SubscriptionHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionHistory_SubscriptionId",
                table: "SubscriptionHistory",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionHistory",
                table: "SubscriptionHistory");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionHistory_SubscriptionId",
                table: "SubscriptionHistory");

            migrationBuilder.DropColumn(
                name: "SubscriptionHistoryId",
                table: "SubscriptionHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionHistory",
                table: "SubscriptionHistory",
                column: "SubscriptionId");
        }
    }
}
