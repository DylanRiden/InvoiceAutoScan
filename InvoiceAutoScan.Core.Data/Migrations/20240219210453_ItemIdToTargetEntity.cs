using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceAutoScan.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class ItemIdToTargetEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                schema: "Core",
                table: "TargetEntities",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Core",
                table: "TargetEntities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                schema: "Core",
                table: "TargetEntities",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                schema: "Core",
                table: "TargetEntities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SourceSystemId",
                schema: "Core",
                table: "TargetEntities",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TargetEntities_SourceSystemId",
                schema: "Core",
                table: "TargetEntities",
                column: "SourceSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TargetEntities_SourceSystems_SourceSystemId",
                schema: "Core",
                table: "TargetEntities",
                column: "SourceSystemId",
                principalSchema: "Core",
                principalTable: "SourceSystems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TargetEntities_SourceSystems_SourceSystemId",
                schema: "Core",
                table: "TargetEntities");

            migrationBuilder.DropIndex(
                name: "IX_TargetEntities_SourceSystemId",
                schema: "Core",
                table: "TargetEntities");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Core",
                table: "TargetEntities");

            migrationBuilder.DropColumn(
                name: "Identifier",
                schema: "Core",
                table: "TargetEntities");

            migrationBuilder.DropColumn(
                name: "ItemId",
                schema: "Core",
                table: "TargetEntities");

            migrationBuilder.DropColumn(
                name: "SourceSystemId",
                schema: "Core",
                table: "TargetEntities");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                schema: "Core",
                table: "TargetEntities",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
