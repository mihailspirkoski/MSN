using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSN_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FinalDbVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
