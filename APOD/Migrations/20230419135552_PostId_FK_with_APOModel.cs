using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APOD.Migrations
{
    /// <inheritdoc />
    public partial class PostId_FK_with_APOModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_PostId",
                table: "CommentModel",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_APODModel_PostId",
                table: "CommentModel",
                column: "PostId",
                principalTable: "APODModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_APODModel_PostId",
                table: "CommentModel");

            migrationBuilder.DropIndex(
                name: "IX_CommentModel_PostId",
                table: "CommentModel");
        }
    }
}
