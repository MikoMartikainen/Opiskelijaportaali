using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opiskelijaportaali.Migrations
{
    /// <inheritdoc />
    public partial class MergeEventDateAndTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "EventDate",
                table: "Events",
                newName: "EventDateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Bdate",
                table: "Profiles",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventDateTime",
                table: "Events",
                newName: "EventDate");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Bdate",
                keyValue: null,
                column: "Bdate",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Bdate",
                table: "Profiles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Events",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
