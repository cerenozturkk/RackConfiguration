using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RackConfigurationn.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxLoadCapacity = table.Column<double>(type: "float", nullable: false),
                    IsDeck = table.Column<bool>(type: "bit", nullable: false),
                    DeckType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeckOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Depth = table.Column<double>(type: "float", nullable: false),
                    DeckType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Racks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalHeight = table.Column<double>(type: "float", nullable: false),
                    TotalDepth = table.Column<double>(type: "float", nullable: false),
                    IsAddOnRack = table.Column<bool>(type: "bit", nullable: false),
                    IsDoubleSided = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentPrices_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelfUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<double>(type: "float", nullable: false),
                    UnitWidth = table.Column<double>(type: "float", nullable: false),
                    NumberOfDecks = table.Column<int>(type: "int", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    RackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelfUnits_Racks_RackId",
                        column: x => x.RackId,
                        principalTable: "Racks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeckType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    ShelfUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decks_ShelfUnits_ShelfUnitId",
                        column: x => x.ShelfUnitId,
                        principalTable: "ShelfUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Id", "Category", "ComponentId", "DeckType", "IsDeck", "Material", "MaxLoadCapacity", "Name" },
                values: new object[,]
                {
                    { 1, "Upright", null, null, false, "Çelik", 1000.0, "Ana Dikme (3.5m)" },
                    { 2, "Upright", null, null, false, "Çelik", 1000.0, "Yan Dikme (3.5m)" },
                    { 3, "Beam", null, null, false, "Çelik", 500.0, "Kiriş (220cm)" },
                    { 4, "Beam", null, null, false, "Çelik", 250.0, "Kiriş (110cm)" },
                    { 5, "Panel", null, "With wooden deck", true, "Ahşap", 300.0, "Ahşap Kapak" },
                    { 6, "Panel", null, "With steel deck", true, "Çelik", 350.0, "Çelik Kapak" },
                    { 7, "Panel", null, "With galvanised mesh deck", true, "Galvaniz", 400.0, "Galvanizli Izgara" },
                    { 8, "Panel", null, "Inclined deck", true, "Çelik", 100.0, "Eğimli Kapak" },
                    { 9, "Panel", null, "Multiplex board", true, "Kompozit", 300.0, "Multiplex Pano" },
                    { 10, "Panel", null, "Without layers", true, "Yok", 0.0, "Katman Yok" }
                });

            migrationBuilder.InsertData(
                table: "DeckOptions",
                columns: new[] { "Id", "DeckType", "Depth", "ImageUrl" },
                values: new object[,]
                {
                    { 1, "Without layers", 40.0, "/imagesdecktypes/withoutlayers.jpg" },
                    { 2, "With wooden deck", 40.0, "/imagesdecktypes/woodendeck.jpg" },
                    { 3, "With steel deck", 40.0, "/imagesdecktypes/steeldeck.jpg" },
                    { 4, "Without layers", 50.0, "/imagesdecktypes/withoutlayers.jpg" },
                    { 5, "With wooden deck", 50.0, "/imagesdecktypes/woodendeck.jpg" },
                    { 6, "With steel deck", 50.0, "/imagesdecktypes/steeldeck.jpg" },
                    { 7, "Without layers", 60.0, "/imagesdecktypes/withoutlayers.jpg" },
                    { 8, "With wooden deck", 60.0, "/imagesdecktypes/woodendeck.jpg" },
                    { 9, "With steel deck", 60.0, "/imagesdecktypes/steeldeck.jpg" },
                    { 10, "With galvanised mesh deck", 60.0, "/imagesdecktypes/galvaniseddeck.jpg" },
                    { 11, "Inclined deck", 60.0, "/imagesdecktypes/inclineddeck.jpg" },
                    { 12, "Multiplex board", 60.0, "/imagesdecktypes/multiplexdeck.jpg" },
                    { 13, "Without layers", 80.0, "/imagesdecktypes/withoutlayers.jpg" },
                    { 14, "With wooden deck", 80.0, "/imagesdecktypes/woodendeck.jpg" },
                    { 15, "With steel deck", 80.0, "/imagesdecktypes/steeldeck.jpg" },
                    { 16, "With galvanised mesh deck", 80.0, "/imagesdecktypes/galvaniseddeck.jpg" },
                    { 17, "Inclined deck", 80.0, "/imagesdecktypes/inclineddeck.jpg" },
                    { 18, "Multiplex board", 80.0, "/imagesdecktypes/multiplexdeck.jpg" },
                    { 19, "Without layers", 100.0, "/imagesdecktypes/withoutlayers.jpg" },
                    { 20, "With wooden deck", 100.0, "/imagesdecktypes/woodendeck.jpg" },
                    { 21, "With steel deck", 100.0, "/imagesdecktypes/steeldeck.jpg" },
                    { 22, "Without layers", 120.0, "/imagesdecktypes/withoutlayers.jpg" },
                    { 23, "With wooden deck", 120.0, "/imagesdecktypes/woodendeck.jpg" },
                    { 24, "With steel deck", 120.0, "/imagesdecktypes/steeldeck.jpg" },
                    { 25, "With galvanised mesh deck", 120.0, "/imagesdecktypes/galvaniseddeck.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ComponentPrices",
                columns: new[] { "Id", "ComponentId", "EffectiveDate", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.0 },
                    { 2, 2, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0 },
                    { 3, 3, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0 },
                    { 4, 4, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0 },
                    { 5, 5, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.0 },
                    { 6, 6, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0 },
                    { 7, 7, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.0 },
                    { 8, 8, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 22.0 },
                    { 9, 9, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.0 },
                    { 10, 10, new DateTime(2025, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentPrices_ComponentId",
                table: "ComponentPrices",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentId",
                table: "Components",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_ShelfUnitId",
                table: "Decks",
                column: "ShelfUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelfUnits_RackId",
                table: "ShelfUnits",
                column: "RackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComponentPrices");

            migrationBuilder.DropTable(
                name: "DeckOptions");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "ShelfUnits");

            migrationBuilder.DropTable(
                name: "Racks");
        }
    }
}
