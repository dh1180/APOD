using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APOD.Migrations
{
    /// <inheritdoc />
    public partial class Delete_Comments_property_in_APODModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_APODModel_APODModelId",
                table: "CommentModel");

            migrationBuilder.DropIndex(
                name: "IX_CommentModel_APODModelId",
                table: "CommentModel");

            migrationBuilder.DropColumn(
                name: "APODModelId",
                table: "CommentModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "APODModelId",
                table: "CommentModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_APODModelId",
                table: "CommentModel",
                column: "APODModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_APODModel_APODModelId",
                table: "CommentModel",
                column: "APODModelId",
                principalTable: "APODModel",
                principalColumn: "Id");
        }
    }
}
