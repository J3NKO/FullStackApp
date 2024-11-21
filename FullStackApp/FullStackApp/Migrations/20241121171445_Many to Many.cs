﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullStackApp.Migrations
{
    /// <inheritdoc />
    public partial class ManytoMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemClients",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ItemClientClientId = table.Column<int>(type: "int", nullable: true),
                    ItemClientItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemClients", x => new { x.ItemId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_ItemClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemClients_ItemClients_ItemClientItemId_ItemClientClientId",
                        columns: x => new { x.ItemClientItemId, x.ItemClientClientId },
                        principalTable: "ItemClients",
                        principalColumns: new[] { "ItemId", "ClientId" });
                    table.ForeignKey(
                        name: "FK_ItemClients_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemClients_ClientId",
                table: "ItemClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemClients_ItemClientItemId_ItemClientClientId",
                table: "ItemClients",
                columns: new[] { "ItemClientItemId", "ItemClientClientId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemClients");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
