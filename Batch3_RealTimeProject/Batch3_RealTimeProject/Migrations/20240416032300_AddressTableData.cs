using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Batch3_RealTimeProject.Migrations
{
    /// <inheritdoc />
    public partial class AddressTableData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "AddressLine1", "AddressLine2", "City", "PhoneNumber", "State" },
                values: new object[,]
                {
                    { 1, "123 Louisa Lane", "Camp Hill Road", "Perrysburg", "(123)456-7890", "Ohio" },
                    { 2, "345 Chenal Pkwy", "Gate Way", "Little Rock", "(123)456-7890", "Arkansas" },
                    { 3, "64 Secane way", "Clifton Hills", "Dallas", "(123)456-7890", "Texas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: 3);
        }
    }
}
