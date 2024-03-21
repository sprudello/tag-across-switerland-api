using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TagAPI.Migrations
{
    /// <inheritdoc />
    public partial class initiallapi4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasMultiplier",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasMultiplier",
                table: "Users");
        }
    }
}
