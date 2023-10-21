using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeyFromVotesToEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "PollEventId");

            migrationBuilder.AddColumn<int>(
                name: "PollEventId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 21, 22, 8, 7, 541, DateTimeKind.Local).AddTicks(6625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 16, 31, 10, 752, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.CreateIndex(
                name: "IX_Votes_PollOptionId",
                table: "Votes",
                column: "PollOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_EventOptions_PollOptionId",
                table: "Votes",
                column: "PollOptionId",
                principalTable: "EventOptions",
                principalColumn: "PollOptionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_EventOptions_PollOptionId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_PollOptionId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "PollEventId",
                table: "Votes");

            migrationBuilder.RenameColumn(
                name: "PollEventId",
                table: "Events",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 16, 31, 10, 752, DateTimeKind.Local).AddTicks(5365),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 21, 22, 8, 7, 541, DateTimeKind.Local).AddTicks(6625));
        }
    }
}
