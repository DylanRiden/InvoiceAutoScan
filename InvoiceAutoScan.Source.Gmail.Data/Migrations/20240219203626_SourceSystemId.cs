using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceAutoScan.Source.Gmail.Data.Migrations
{
    /// <inheritdoc />
    public partial class SourceSystemId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SourceSystemId",
                schema: "Sources.Gmail",
                table: "ImportedMessages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceSystemId",
                schema: "Sources.Gmail",
                table: "ImportedMessages");
        }
    }
}
