using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustesEndPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GarcomRestaurante_StatusGarcom_StatusId",
                table: "GarcomRestaurante");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Cardapio_CardapioId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Cozinha_CozinhaId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Mesa_StatusMesa_StatusId",
                table: "Mesa");

            migrationBuilder.DropTable(
                name: "StatusCozinha");

            migrationBuilder.DropTable(
                name: "StatusGarcom");

            migrationBuilder.DropTable(
                name: "Cozinha");

            migrationBuilder.DropIndex(
                name: "IX_Mesa_StatusId",
                table: "Mesa");

            migrationBuilder.DropIndex(
                name: "IX_Item_CardapioId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CozinhaId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_GarcomRestaurante_StatusId",
                table: "GarcomRestaurante");

            migrationBuilder.DropColumn(
                name: "DataHora",
                table: "StatusMesa");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "StatusMesa");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Mesa");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "ItemPedido");

            migrationBuilder.DropColumn(
                name: "CardapioId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CozinhaId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "GarcomRestaurante");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "StatusPedido",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "StatusItemPedido",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "StatusMesa",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Pedido",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusMesaId",
                table: "Mesa",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "ItemPedido",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitario",
                table: "ItemPedido",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "StatusMesa",
                columns: new[] { "Id", "StatusId" },
                values: new object[,]
                {
                    { 1, "Desocupada" },
                    { 2, "Ocupada" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_StatusMesaId",
                table: "Mesa",
                column: "StatusMesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mesa_StatusMesa_StatusMesaId",
                table: "Mesa",
                column: "StatusMesaId",
                principalTable: "StatusMesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mesa_StatusMesa_StatusMesaId",
                table: "Mesa");

            migrationBuilder.DropIndex(
                name: "IX_Mesa_StatusMesaId",
                table: "Mesa");

            migrationBuilder.DeleteData(
                table: "StatusMesa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusMesa",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "StatusMesa");

            migrationBuilder.DropColumn(
                name: "StatusMesaId",
                table: "Mesa");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "ItemPedido");

            migrationBuilder.DropColumn(
                name: "PrecoUnitario",
                table: "ItemPedido");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "StatusPedido",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "StatusItemPedido",
                newName: "Descricao");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHora",
                table: "StatusMesa",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "StatusMesa",
                type: "VARCHAR(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Pedido",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Mesa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "ItemPedido",
                type: "VARCHAR(250)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CardapioId",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CozinhaId",
                table: "Item",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "GarcomRestaurante",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cozinha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RestauranteId = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cozinha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cozinha_Restaurante_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusGarcom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusGarcom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCozinha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CozinhaId = table.Column<int>(type: "integer", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCozinha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusCozinha_Cozinha_CozinhaId",
                        column: x => x.CozinhaId,
                        principalTable: "Cozinha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_StatusId",
                table: "Mesa",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CardapioId",
                table: "Item",
                column: "CardapioId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CozinhaId",
                table: "Item",
                column: "CozinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_GarcomRestaurante_StatusId",
                table: "GarcomRestaurante",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Cozinha_RestauranteId",
                table: "Cozinha",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusCozinha_CozinhaId",
                table: "StatusCozinha",
                column: "CozinhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_GarcomRestaurante_StatusGarcom_StatusId",
                table: "GarcomRestaurante",
                column: "StatusId",
                principalTable: "StatusGarcom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Cardapio_CardapioId",
                table: "Item",
                column: "CardapioId",
                principalTable: "Cardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Cozinha_CozinhaId",
                table: "Item",
                column: "CozinhaId",
                principalTable: "Cozinha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mesa_StatusMesa_StatusId",
                table: "Mesa",
                column: "StatusId",
                principalTable: "StatusMesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
