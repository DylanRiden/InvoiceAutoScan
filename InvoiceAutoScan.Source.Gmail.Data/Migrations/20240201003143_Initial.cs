using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceAutoScan.Source.Gmail.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sources.Gmail");

            migrationBuilder.CreateTable(
                name: "ImportedMessages",
                schema: "Sources.Gmail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    InternalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HistoryId = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    From = table.Column<string>(type: "text", nullable: false),
                    SourceId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportedMessages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportedMessages_SourceId",
                schema: "Sources.Gmail",
                table: "ImportedMessages",
                column: "SourceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportedMessages",
                schema: "Sources.Gmail");
        }
    }
}
