using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opiskelijaportaali.Migrations
{
    /// <inheritdoc />
    public partial class CreateTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(table: "Events", columns: new[] { "Title", "EventDateTime", "Description" }, values: new object[,] { { "Testi", "2025-10-26 10:00:00", "Testi tapahtuma" }, { "Testi2", "2025-10-27 13:00:00", "Testi2 tapahtuma" } });
            migrationBuilder.InsertData(table: "Profiles", columns: new[] { "FName", "LName", "Email", "Bdate", "Phone" }, values: new object[,] { { "Ellin", "Testi", "testi@example.com", "2025-10-26 08:23:18.467000", "0441234567" }, { "Joku", "Tyyppi", "jokutyyppi@example.com", "2025-10-26 08:23:18.467000", "0441234577" } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
