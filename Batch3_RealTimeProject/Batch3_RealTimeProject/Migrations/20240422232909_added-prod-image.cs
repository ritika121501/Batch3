using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Batch3_RealTimeProject.Migrations
{
    /// <inheritdoc />
    public partial class addedprodimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrl",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageUrl",
                table: "Product");
        }
    }
}
