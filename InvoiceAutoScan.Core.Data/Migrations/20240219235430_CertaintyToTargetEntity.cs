using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceAutoScan.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class CertaintyToTargetEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Certainty",
                schema: "Core",
                table: "TargetEntities",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certainty",
                schema: "Core",
                table: "TargetEntities");
        }
    }
}
