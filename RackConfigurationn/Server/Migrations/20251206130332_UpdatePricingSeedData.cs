using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RackConfigurationn.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePricingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 5,
                column: "Depth",
                value: 40);

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ComponentId", "Depth", "Price" },
                values: new object[] { 5, 50, 22.0 });

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ComponentId", "Depth", "Price" },
                values: new object[] { 5, 60, 26.0 });

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ComponentId", "Depth", "Price" },
                values: new object[] { 5, 80, 34.0 });

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ComponentId", "Depth", "Price" },
                values: new object[] { 5, 100, 42.0 });

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ComponentId", "Depth", "Price" },
                values: new object[] { 5, 120, 50.0 });

            migrationBuilder.InsertData(
                table: "ComponentPrices",
                columns: new[] { "Id", "ComponentId", "Depth", "EffectiveDate", "Price" },
                values: new object[,]
                {
                    { 11, 6, 40, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0 },
                    { 12, 6, 50, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0 },
                    { 13, 6, 60, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.0 },
                    { 14, 6, 80, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.0 },
                    { 15, 6, 100, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.0 },
                    { 16, 6, 120, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.0 },
                    { 17, 7, 60, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.0 },
                    { 18, 7, 80, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.0 },
                    { 19, 7, 120, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.0 },
                    { 20, 8, null, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 22.0 },
                    { 21, 9, null, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.0 },
                    { 22, 10, null, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 5,
                column: "Depth",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ComponentId", "Depth", "Price" },
                values: new object[] { 6, null, 25.0 });

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ComponentId", "Depth", "Price" },
                values: new object[] { 7, null, 35.0 });

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ComponentId", "Depth", "Price" },
                values: new object[] { 8, null, 22.0 });

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ComponentId", "Depth", "Price" },
                values: new object[] { 9, null, 28.0 });

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ComponentId", "Depth", "Price" },
                values: new object[] { 10, null, 0.0 });
        }
    }
}
