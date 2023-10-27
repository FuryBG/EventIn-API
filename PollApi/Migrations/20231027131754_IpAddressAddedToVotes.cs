using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollApi.Migrations
{
    /// <inheritdoc />
    public partial class IpAddressAddedToVotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Votes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 27, 16, 17, 54, 381, DateTimeKind.Local).AddTicks(2897),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 21, 22, 8, 7, 541, DateTimeKind.Local).AddTicks(6625));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Votes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 21, 22, 8, 7, 541, DateTimeKind.Local).AddTicks(6625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 27, 16, 17, 54, 381, DateTimeKind.Local).AddTicks(2897));
        }
    }
}
