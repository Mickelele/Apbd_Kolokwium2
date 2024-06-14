using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolosAPBD.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CurrentWeight = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    TitleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.TitleID);
                });

            migrationBuilder.CreateTable(
                name: "Backpacks",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backpacks", x => new { x.ItemID, x.CharacterID });
                    table.ForeignKey(
                        name: "FK_Backpacks_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Backpacks_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character_Titles",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false),
                    TitleID = table.Column<int>(type: "int", nullable: false),
                    AcquiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character_Titles", x => new { x.CharacterID, x.TitleID });
                    table.ForeignKey(
                        name: "FK_Character_Titles_Characters_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Characters",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Titles_Titles_TitleID",
                        column: x => x.TitleID,
                        principalTable: "Titles",
                        principalColumn: "TitleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterID", "CurrentWeight", "FirstName", "LastName", "MaxWeight" },
                values: new object[] { 1, 80, "Anakin", "Skywalker", 120 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "Name", "Weight" },
                values: new object[] { 1, "Miecz swietlny", 10 });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "TitleID", "Name" },
                values: new object[] { 1, "Jedi" });

            migrationBuilder.InsertData(
                table: "Backpacks",
                columns: new[] { "CharacterID", "ItemID", "Amount" },
                values: new object[] { 1, 1, 5 });

            migrationBuilder.InsertData(
                table: "Character_Titles",
                columns: new[] { "CharacterID", "TitleID", "AcquiredAt" },
                values: new object[] { 1, 1, new DateTime(2024, 6, 14, 12, 33, 30, 691, DateTimeKind.Local).AddTicks(196) });

            migrationBuilder.CreateIndex(
                name: "IX_Backpacks_CharacterID",
                table: "Backpacks",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Character_Titles_TitleID",
                table: "Character_Titles",
                column: "TitleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Backpacks");

            migrationBuilder.DropTable(
                name: "Character_Titles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
