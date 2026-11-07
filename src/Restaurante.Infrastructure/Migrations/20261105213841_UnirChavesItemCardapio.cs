using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnirChavesItemCardapio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemCardapio_CardapioId_ItemId",
                table: "ItemCardapio");

            migrationBuilder.UpdateData(
                table: "StatusItemPedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataHora",
                value: new DateTime(2026, 11, 5, 21, 38, 41, 384, DateTimeKind.Utc).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "StatusItemPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataHora",
                value: new DateTime(2026, 11, 5, 21, 38, 41, 384, DateTimeKind.Utc).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataHora",
                value: new DateTime(2026, 11, 5, 21, 38, 41, 385, DateTimeKind.Utc).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataHora",
                value: new DateTime(2026, 11, 5, 21, 38, 41, 385, DateTimeKind.Utc).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataHora",
                value: new DateTime(2026, 11, 5, 21, 38, 41, 385, DateTimeKind.Utc).AddTicks(3009));

            migrationBuilder.CreateIndex(
                name: "IX_ItemCardapio_CardapioId_ItemId",
                table: "ItemCardapio",
                columns: new[] { "CardapioId", "ItemId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemCardapio_CardapioId_ItemId",
                table: "ItemCardapio");

            migrationBuilder.UpdateData(
                table: "StatusItemPedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataHora",
                value: new DateTime(2026, 10, 29, 16, 41, 15, 950, DateTimeKind.Utc).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "StatusItemPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataHora",
                value: new DateTime(2026, 10, 29, 16, 41, 15, 950, DateTimeKind.Utc).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataHora",
                value: new DateTime(2026, 10, 29, 16, 41, 15, 950, DateTimeKind.Utc).AddTicks(8514));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataHora",
                value: new DateTime(2026, 10, 29, 16, 41, 15, 950, DateTimeKind.Utc).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataHora",
                value: new DateTime(2026, 10, 29, 16, 41, 15, 950, DateTimeKind.Utc).AddTicks(8522));

            migrationBuilder.CreateIndex(
                name: "IX_ItemCardapio_CardapioId_ItemId",
                table: "ItemCardapio",
                columns: new[] { "CardapioId", "ItemId" });
        }
    }
}
