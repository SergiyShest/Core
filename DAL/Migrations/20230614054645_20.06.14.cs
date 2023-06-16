using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class _200614 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                schema: "korfin",
                table: "Users",
                type: "character varying(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(char),
                oldType: "character(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CDate",
                schema: "korfin",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CUser",
                schema: "korfin",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LDate",
                schema: "korfin",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LUser",
                schema: "korfin",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserOstId",
                schema: "korfin",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkOstId",
                schema: "korfin",
                table: "Users",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CDate",
                schema: "korfin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CUser",
                schema: "korfin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LDate",
                schema: "korfin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LUser",
                schema: "korfin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserOstId",
                schema: "korfin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WorkOstId",
                schema: "korfin",
                table: "Users");

            migrationBuilder.AlterColumn<char>(
                name: "Comment",
                schema: "korfin",
                table: "Users",
                type: "character(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1)",
                oldMaxLength: 1,
                oldNullable: true);
        }
    }
}
