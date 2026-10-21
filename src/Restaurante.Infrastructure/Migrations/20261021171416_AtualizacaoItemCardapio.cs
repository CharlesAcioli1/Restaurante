using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Restaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoItemCardapio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCardapio",
                table: "ItemCardapio");

            migrationBuilder.AddColumn<int>(
                name: "ItemCardapioId",
                table: "ItemPedido",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItemCardapio",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCardapio",
                table: "ItemCardapio",
                column: "Id");

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
                name: "IX_ItemPedido_ItemCardapioId",
                table: "ItemPedido",
                column: "ItemCardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCardapio_CardapioId_ItemId",
                table: "ItemCardapio",
                columns: new[] { "CardapioId", "ItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedido_ItemCardapio_ItemCardapioId",
                table: "ItemPedido",
                column: "ItemCardapioId",
                principalTable: "ItemCardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedido_ItemCardapio_ItemCardapioId",
                table: "ItemPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItemPedido_ItemCardapioId",
                table: "ItemPedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCardapio",
                table: "ItemCardapio");

            migrationBuilder.DropIndex(
                name: "IX_ItemCardapio_CardapioId_ItemId",
                table: "ItemCardapio");

            migrationBuilder.DropColumn(
                name: "ItemCardapioId",
                table: "ItemPedido");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemCardapio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCardapio",
                table: "ItemCardapio",
                columns: new[] { "CardapioId", "ItemId" });

            migrationBuilder.UpdateData(
                table: "StatusItemPedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataHora",
                value: new DateTime(2026, 10, 16, 17, 31, 16, 227, DateTimeKind.Utc).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "StatusItemPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataHora",
                value: new DateTime(2026, 10, 16, 17, 31, 16, 227, DateTimeKind.Utc).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataHora",
                value: new DateTime(2026, 10, 16, 17, 31, 16, 227, DateTimeKind.Utc).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataHora",
                value: new DateTime(2026, 10, 16, 17, 31, 16, 227, DateTimeKind.Utc).AddTicks(5229));

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataHora",
                value: new DateTime(2026, 10, 16, 17, 31, 16, 227, DateTimeKind.Utc).AddTicks(5230));
        }
    }
}
