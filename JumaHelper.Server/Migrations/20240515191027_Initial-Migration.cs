using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JumaDayHelperWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuaRequestOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FatherName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuaRequestOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DuaRequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 800, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuaRequestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DuaRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestTo_Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    RequestTo_Affiliation = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 3000, nullable: true),
                    DuaRequestOwnerId = table.Column<int>(type: "INTEGER", nullable: true),
                    DuaRequestTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuaRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuaRequests_DuaRequestOwners_DuaRequestOwnerId",
                        column: x => x.DuaRequestOwnerId,
                        principalTable: "DuaRequestOwners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DuaRequests_DuaRequestTypes_DuaRequestTypeId",
                        column: x => x.DuaRequestTypeId,
                        principalTable: "DuaRequestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DuaRequestTypes",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kesellikke shıpa" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ata-anası haqqına jaqsılıq" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Jumisının' júrisiwin" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Qarızınan qutılıw" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Perzent sorap" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Basqa sebeb benen" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuaRequestTypes_Name",
                table: "DuaRequestTypes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DuaRequests_DuaRequestOwnerId",
                table: "DuaRequests",
                column: "DuaRequestOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DuaRequests_DuaRequestTypeId",
                table: "DuaRequests",
                column: "DuaRequestTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuaRequests");

            migrationBuilder.DropTable(
                name: "DuaRequestOwners");

            migrationBuilder.DropTable(
                name: "DuaRequestTypes");
        }
    }
}
