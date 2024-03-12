using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TheatreDetails",
                table: "TheatreDetails");

            migrationBuilder.RenameTable(
                name: "TheatreDetails",
                newName: "TheatreDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TheatreDetail",
                table: "TheatreDetail",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TheatreDetail",
                table: "TheatreDetail");

            migrationBuilder.RenameTable(
                name: "TheatreDetail",
                newName: "TheatreDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TheatreDetails",
                table: "TheatreDetails",
                column: "Id");
        }
    }
}
