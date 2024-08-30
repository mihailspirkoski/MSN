using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSN_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RevertedChangesToMigrationNumber2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "type",
                table: "MusicRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "genre",
                table: "MusicRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "type",
                table: "ForumPosts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "genre",
                table: "ForumPosts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AddColumn<string>(
                name: "MSNUserId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MSNUserMusicRecord",
                columns: table => new
                {
                    likedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    likedRecordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSNUserMusicRecord", x => new { x.likedById, x.likedRecordsId });
                    table.ForeignKey(
                        name: "FK_MSNUserMusicRecord_AspNetUsers_likedById",
                        column: x => x.likedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MSNUserMusicRecord_MusicRecords_likedRecordsId",
                        column: x => x.likedRecordsId,
                        principalTable: "MusicRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_CreatedByUser",
                table: "ForumPosts",
                column: "CreatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MSNUserId",
                table: "AspNetUsers",
                column: "MSNUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MSNUserMusicRecord_likedRecordsId",
                table: "MSNUserMusicRecord",
                column: "likedRecordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_MSNUserId",
                table: "AspNetUsers",
                column: "MSNUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_AspNetUsers_CreatedByUser",
                table: "ForumPosts",
                column: "CreatedByUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_MSNUserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_AspNetUsers_CreatedByUser",
                table: "ForumPosts");

            migrationBuilder.DropTable(
                name: "MSNUserMusicRecord");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_CreatedByUser",
                table: "ForumPosts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MSNUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "ForumPosts");

            migrationBuilder.DropColumn(
                name: "MSNUserId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "MusicRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "MusicRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "ForumPosts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "ForumPosts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
