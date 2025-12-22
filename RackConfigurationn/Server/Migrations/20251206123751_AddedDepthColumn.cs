using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RackConfigurationn.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedDepthColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalDepth",
                table: "Racks",
                newName: "Depth");

            migrationBuilder.AddColumn<int>(
                name: "Depth",
                table: "ComponentPrices",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Depth",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "Depth",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 3,
                column: "Depth",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 4,
                column: "Depth",
                value: null);

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
                column: "Depth",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 7,
                column: "Depth",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 8,
                column: "Depth",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 9,
                column: "Depth",
                value: null);

            migrationBuilder.UpdateData(
                table: "ComponentPrices",
                keyColumn: "Id",
                keyValue: 10,
                column: "Depth",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Depth",
                table: "ComponentPrices");

            migrationBuilder.RenameColumn(
                name: "Depth",
                table: "Racks",
                newName: "TotalDepth");
        }
    }
}
