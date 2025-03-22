using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Teachers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "link",
                table: "Teachers",
                newName: "Link");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Teachers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "schoolName",
                table: "Principals",
                newName: "SchoolName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Principals",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Principals",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "citySchool",
                table: "Principals",
                newName: "CitySchool");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Principals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "paswword",
                table: "Principals",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teachers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Teachers",
                newName: "link");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Teachers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SchoolName",
                table: "Principals",
                newName: "schoolName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Principals",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Principals",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CitySchool",
                table: "Principals",
                newName: "citySchool");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Principals",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Principals",
                newName: "paswword");
        }
    }
}
