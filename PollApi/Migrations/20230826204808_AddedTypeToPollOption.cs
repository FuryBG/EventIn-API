using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedTypeToPollOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "EventOptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "EventOptions");
        }
    }
}
