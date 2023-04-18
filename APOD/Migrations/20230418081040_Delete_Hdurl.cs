using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APOD.Migrations
{
    /// <inheritdoc />
    public partial class Delete_Hdurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hdurl",
                table: "APODModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hdurl",
                table: "APODModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
