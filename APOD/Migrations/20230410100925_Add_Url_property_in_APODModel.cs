using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APOD.Migrations
{
    /// <inheritdoc />
    public partial class Add_Url_property_in_APODModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "APODModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "APODModel");
        }
    }
}
