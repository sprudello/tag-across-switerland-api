using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TagAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialPC2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PenaltyEndTime",
                table: "UserChallenges");

            migrationBuilder.AddColumn<DateTime>(
                name: "PenaltyEndTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PenaltyEndTime",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "PenaltyEndTime",
                table: "UserChallenges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
