using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPollOptionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventOptions_Events_PollEventId",
                table: "EventOptions");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventOptions");

            migrationBuilder.AlterColumn<int>(
                name: "PollEventId",
                table: "EventOptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventOptions_Events_PollEventId",
                table: "EventOptions",
                column: "PollEventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventOptions_Events_PollEventId",
                table: "EventOptions");

            migrationBuilder.AlterColumn<int>(
                name: "PollEventId",
                table: "EventOptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EventOptions_Events_PollEventId",
                table: "EventOptions",
                column: "PollEventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
