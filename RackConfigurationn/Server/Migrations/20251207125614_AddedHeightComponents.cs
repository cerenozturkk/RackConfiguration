using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RackConfigurationn.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedHeightComponents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Id", "Category", "ComponentId", "DeckType", "IsDeck", "Material", "MaxLoadCapacity", "Name" },
                values: new object[,]
                {
                    { 30, "Upright", null, null, false, "Çelik", 800.0, "Ana Dikme (2m)" },
                    { 31, "Upright", null, null, false, "Çelik", 800.0, "Yan Dikme (2m)" },
                    { 32, "Upright", null, null, false, "Çelik", 900.0, "Ana Dikme (2.5m)" },
                    { 33, "Upright", null, null, false, "Çelik", 900.0, "Yan Dikme (2.5m)" },
                    { 34, "Upright", null, null, false, "Çelik", 1000.0, "Ana Dikme (3m)" },
                    { 35, "Upright", null, null, false, "Çelik", 1000.0, "Yan Dikme (3m)" }
                });

            migrationBuilder.InsertData(
                table: "ComponentPrices",
                columns: new[] { "Id", "ComponentId", "Depth", "EffectiveDate", "Price" },
                values: new object[,]
                {
                    { 30, 30, null, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.0 },
                    { 31, 31, null, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0 },
                    { 32, 32, null, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 42.0 },
                    { 33, 33, null, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.0 },
                    { 34, 34, null, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.0 },
                    { 35, 35, null, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 44.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Id",
                keyValue: 35);
        }
    }
}
