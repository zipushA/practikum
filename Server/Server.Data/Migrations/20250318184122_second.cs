using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Principals_MatchingData_demandId",
                table: "Principals");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_MatchingData_dataId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "dataId",
                table: "Teachers",
                newName: "MatchingDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_dataId",
                table: "Teachers",
                newName: "IX_Teachers_MatchingDataId");

            migrationBuilder.RenameColumn(
                name: "demandId",
                table: "Principals",
                newName: "MatchingDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Principals_demandId",
                table: "Principals",
                newName: "IX_Principals_MatchingDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Principals_MatchingData_MatchingDataId",
                table: "Principals",
                column: "MatchingDataId",
                principalTable: "MatchingData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_MatchingData_MatchingDataId",
                table: "Teachers",
                column: "MatchingDataId",
                principalTable: "MatchingData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Principals_MatchingData_MatchingDataId",
                table: "Principals");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_MatchingData_MatchingDataId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "MatchingDataId",
                table: "Teachers",
                newName: "dataId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_MatchingDataId",
                table: "Teachers",
                newName: "IX_Teachers_dataId");

            migrationBuilder.RenameColumn(
                name: "MatchingDataId",
                table: "Principals",
                newName: "demandId");

            migrationBuilder.RenameIndex(
                name: "IX_Principals_MatchingDataId",
                table: "Principals",
                newName: "IX_Principals_demandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Principals_MatchingData_demandId",
                table: "Principals",
                column: "demandId",
                principalTable: "MatchingData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_MatchingData_dataId",
                table: "Teachers",
                column: "dataId",
                principalTable: "MatchingData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
