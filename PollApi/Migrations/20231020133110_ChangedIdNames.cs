using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIdNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Votes",
                newName: "PollVoteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EventOptions",
                newName: "PollOptionId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 16, 31, 10, 752, DateTimeKind.Local).AddTicks(5365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 7, 13, 16, 40, 907, DateTimeKind.Local).AddTicks(1736));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PollVoteId",
                table: "Votes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PollOptionId",
                table: "EventOptions",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 7, 13, 16, 40, 907, DateTimeKind.Local).AddTicks(1736),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 16, 31, 10, 752, DateTimeKind.Local).AddTicks(5365));
        }
    }
}
