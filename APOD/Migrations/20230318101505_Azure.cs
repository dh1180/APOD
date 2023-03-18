using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APOD.Migrations
{
    /// <inheritdoc />
    public partial class Azure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_APOD",
                table: "APOD");

            migrationBuilder.RenameTable(
                name: "APOD",
                newName: "APODModel");

            migrationBuilder.RenameColumn(
                name: "hdurl",
                table: "APODModel",
                newName: "Hdurl");

            migrationBuilder.RenameColumn(
                name: "explanation",
                table: "APODModel",
                newName: "Explanation");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "APODModel",
                newName: "Date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APODModel",
                table: "APODModel",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_APODModel",
                table: "APODModel");

            migrationBuilder.RenameTable(
                name: "APODModel",
                newName: "APOD");

            migrationBuilder.RenameColumn(
                name: "Hdurl",
                table: "APOD",
                newName: "hdurl");

            migrationBuilder.RenameColumn(
                name: "Explanation",
                table: "APOD",
                newName: "explanation");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "APOD",
                newName: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APOD",
                table: "APOD",
                column: "Id");
        }
    }
}
