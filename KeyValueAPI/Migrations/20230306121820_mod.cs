using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyValueAPI.Migrations
{
    /// <inheritdoc />
    public partial class mod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "KeyValue",
                newName: "KeyValues");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "KeyValues",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KeyValues",
                table: "KeyValues",
                column: "Key");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KeyValues",
                table: "KeyValues");

            migrationBuilder.RenameTable(
                name: "KeyValues",
                newName: "KeyValue");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "KeyValue",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
