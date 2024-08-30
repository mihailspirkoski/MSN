using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSN_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModelsNumber33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_MSNUserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MSNUserMusicRecord");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MSNUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MSNUserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "musicRecordId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_musicRecordId",
                table: "AspNetUsers",
                column: "musicRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MusicRecords_musicRecordId",
                table: "AspNetUsers",
                column: "musicRecordId",
                principalTable: "MusicRecords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MusicRecords_musicRecordId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_musicRecordId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "musicRecordId",
                table: "AspNetUsers");

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
        }
    }
}
