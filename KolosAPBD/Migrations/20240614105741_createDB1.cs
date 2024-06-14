using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolosAPBD.Migrations
{
    /// <inheritdoc />
    public partial class createDB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Backpacks",
                table: "Backpacks");

            migrationBuilder.DropIndex(
                name: "IX_Backpacks_CharacterID",
                table: "Backpacks");

            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterID", "ItemID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "Items",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Backpacks",
                table: "Backpacks",
                columns: new[] { "CharacterID", "ItemID" });

            migrationBuilder.InsertData(
                table: "Backpacks",
                columns: new[] { "CharacterID", "ItemID", "Amount" },
                values: new object[] { 1, 1, 5 });

            migrationBuilder.UpdateData(
                table: "Character_Titles",
                keyColumns: new[] { "CharacterID", "TitleID" },
                keyValues: new object[] { 1, 1 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 14, 12, 57, 40, 987, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.CreateIndex(
                name: "IX_Backpacks_ItemID",
                table: "Backpacks",
                column: "ItemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Backpacks",
                table: "Backpacks");

            migrationBuilder.DropIndex(
                name: "IX_Backpacks_ItemID",
                table: "Backpacks");

            migrationBuilder.DeleteData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterID", "ItemID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Backpacks",
                table: "Backpacks",
                columns: new[] { "ItemID", "CharacterID" });

            migrationBuilder.InsertData(
                table: "Backpacks",
                columns: new[] { "CharacterID", "ItemID", "Amount" },
                values: new object[] { 1, 1, 5 });

            migrationBuilder.UpdateData(
                table: "Character_Titles",
                keyColumns: new[] { "CharacterID", "TitleID" },
                keyValues: new object[] { 1, 1 },
                column: "AcquiredAt",
                value: new DateTime(2024, 6, 14, 12, 33, 30, 691, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.CreateIndex(
                name: "IX_Backpacks_CharacterID",
                table: "Backpacks",
                column: "CharacterID");
        }
    }
}
