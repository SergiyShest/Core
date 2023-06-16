using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "korfin");

            migrationBuilder.CreateTable(
                name: "Osts",
                schema: "korfin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character(100)", fixedLength: true, maxLength: 100, nullable: true),
                    FullName = table.Column<string>(type: "character(200)", fixedLength: true, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Osts_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "korfin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character(100)", fixedLength: true, maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character(100)", fixedLength: true, maxLength: 100, nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Comment = table.Column<char>(type: "character(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Users_pkey", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Osts",
                schema: "korfin");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "korfin");
        }
    }
}
