using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceAutoScan.Source.Gmail.Data.Migrations
{
    /// <inheritdoc />
    public partial class HasFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasFile",
                schema: "Sources.Gmail",
                table: "ImportedMessages",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasFile",
                schema: "Sources.Gmail",
                table: "ImportedMessages");
        }
    }
}
