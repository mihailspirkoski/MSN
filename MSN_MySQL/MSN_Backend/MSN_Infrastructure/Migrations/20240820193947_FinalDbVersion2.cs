using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSN_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinalDbVersion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_AspNetUsers_CreatedByUser",
                table: "ForumPosts");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_CreatedByUser",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "ForumPosts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "ForumPosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "ForumPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_CreatedByUser",
                table: "ForumPosts",
                column: "CreatedByUser");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_AspNetUsers_CreatedByUser",
                table: "ForumPosts",
                column: "CreatedByUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
