using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CitySchool",
                table: "Principals");

            migrationBuilder.DropColumn(
                name: "SchoolName",
                table: "Principals");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "CitySchool",
                table: "Principals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolName",
                table: "Principals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
