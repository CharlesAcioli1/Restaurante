using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ItemCardapio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_Item_ItemId",
                table: "ItemPedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPedido",
                table: "ItemPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItemPedido_ItemId",
                table: "ItemPedido");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemPedido");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPedido",
                table: "ItemPedido",
                columns: new[] { "PedidoId", "ItemCardapioId" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPedido",
                table: "ItemPedido");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemPedido",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPedido",
                table: "ItemPedido",
                columns: new[] { "PedidoId", "ItemId" });

            migrationBuilder.UpdateData(
                table: "StatusItemPedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataHora",
                value: new DateTime(2026, 10, 21, 17, 14, 16, 8, DateTimeKind.Utc).AddTicks(8927));

            migrationBuilder.UpdateData(
                table: "StatusItemPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataHora",
                value: new DateTime(2026, 10, 21, 17, 14, 16, 8, DateTimeKind.Utc).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataHora",
                value: new DateTime(2026, 10, 21, 17, 14, 16, 9, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataHora",
                value: new DateTime(2026, 10, 21, 17, 14, 16, 9, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataHora",
                value: new DateTime(2026, 10, 21, 17, 14, 16, 9, DateTimeKind.Utc).AddTicks(2371));

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_ItemId",
                table: "ItemPedido",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_Item_ItemId",
                table: "ItemPedido",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
