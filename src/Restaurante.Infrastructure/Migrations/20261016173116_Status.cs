using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "StatusPedido",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)");

            migrationBuilder.InsertData(
                table: "StatusItemPedido",
                columns: new[] { "Id", "DataHora", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 16, 17, 31, 16, 227, DateTimeKind.Utc).AddTicks(1621), "NaoEntregue" },
                    { 2, new DateTime(2026, 10, 16, 17, 31, 16, 227, DateTimeKind.Utc).AddTicks(1624), "Entregue" }
                });

            migrationBuilder.InsertData(
                table: "StatusPedido",
                columns: new[] { "Id", "DataHora", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 16, 17, 31, 16, 227, DateTimeKind.Utc).AddTicks(5227), "Enviado" },
                    { 2, new DateTime(2026, 10, 16, 17, 31, 16, 227, DateTimeKind.Utc).AddTicks(5229), "Preparo" },
                    { 3, new DateTime(2026, 10, 16, 17, 31, 16, 227, DateTimeKind.Utc).AddTicks(5230), "Recebido" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatusItemPedido",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusItemPedido",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "StatusPedido",
                type: "VARCHAR(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
