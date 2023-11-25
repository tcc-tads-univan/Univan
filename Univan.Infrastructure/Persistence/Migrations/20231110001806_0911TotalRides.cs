using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univan.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _0911TotalRides : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalRides",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "SubscriptionHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRides",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "SubscriptionHistory");
        }
    }
}
