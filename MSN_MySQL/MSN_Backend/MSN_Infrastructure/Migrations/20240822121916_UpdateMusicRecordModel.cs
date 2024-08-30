using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSN_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMusicRecordModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "MusicRecords");

            migrationBuilder.RenameColumn(
                name: "length",
                table: "MusicRecords",
                newName: "rating");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rating",
                table: "MusicRecords",
                newName: "length");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "MusicRecords",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
