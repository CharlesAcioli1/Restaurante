using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Restaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garcom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garcom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Cnpj = table.Column<string>(type: "VARCHAR(14)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCozinha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCozinha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusGarcom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusGarcom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusItemPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusItemPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusMesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cardapio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    RestauranteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cardapio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cardapio_Restaurante_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cozinha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RestauranteId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Cozinha_StatusCozinha_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusCozinha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GarcomRestaurante",
                columns: table => new
                {
                    GarcomId = table.Column<int>(type: "integer", nullable: false),
                    RestauranteId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarcomRestaurante", x => new { x.GarcomId, x.RestauranteId });
                    table.ForeignKey(
                        name: "FK_GarcomRestaurante_Garcom_GarcomId",
                        column: x => x.GarcomId,
                        principalTable: "Garcom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GarcomRestaurante_Restaurante_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GarcomRestaurante_StatusGarcom_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusGarcom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    RestauranteId = table.Column<int>(type: "integer", nullable: false),
                    Numero = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesa_Restaurante_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mesa_StatusMesa_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusMesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(450)", nullable: false),
                    CozinhaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Cozinha_CozinhaId",
                        column: x => x.CozinhaId,
                        principalTable: "Cozinha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GarcomMesa",
                columns: table => new
                {
                    GarcomId = table.Column<int>(type: "integer", nullable: false),
                    MesaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarcomMesa", x => new { x.GarcomId, x.MesaId });
                    table.ForeignKey(
                        name: "FK_GarcomMesa_Garcom_GarcomId",
                        column: x => x.GarcomId,
                        principalTable: "Garcom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GarcomMesa_Mesa_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdMesa = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Mesa_IdMesa",
                        column: x => x.IdMesa,
                        principalTable: "Mesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_StatusPedido_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCardapio",
                columns: table => new
                {
                    CardapioId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCardapio", x => new { x.CardapioId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemCardapio_Cardapio_CardapioId",
                        column: x => x.CardapioId,
                        principalTable: "Cardapio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCardapio_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilaPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PedidoId = table.Column<int>(type: "integer", nullable: false),
                    Prioridade = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    DataHoraEntrada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilaPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilaPedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemPedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "INT", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedido", x => new { x.PedidoId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ItemPedido_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPedido_StatusItemPedido_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusItemPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cardapio_RestauranteId",
                table: "Cardapio",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cozinha_RestauranteId",
                table: "Cozinha",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Cozinha_StatusId",
                table: "Cozinha",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FilaPedido_PedidoId",
                table: "FilaPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_GarcomMesa_MesaId",
                table: "GarcomMesa",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_GarcomRestaurante_RestauranteId",
                table: "GarcomRestaurante",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_GarcomRestaurante_StatusId",
                table: "GarcomRestaurante",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CozinhaId",
                table: "Item",
                column: "CozinhaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCardapio_ItemId",
                table: "ItemCardapio",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_ItemId",
                table: "ItemPedido",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_StatusId",
                table: "ItemPedido",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_RestauranteId",
                table: "Mesa",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesa_StatusId",
                table: "Mesa",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdMesa",
                table: "Pedido",
                column: "IdMesa");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_StatusId",
                table: "Pedido",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_Cnpj",
                table: "Restaurante",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_Email",
                table: "Restaurante",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilaPedido");

            migrationBuilder.DropTable(
                name: "GarcomMesa");

            migrationBuilder.DropTable(
                name: "GarcomRestaurante");

            migrationBuilder.DropTable(
                name: "ItemCardapio");

            migrationBuilder.DropTable(
                name: "ItemPedido");

            migrationBuilder.DropTable(
                name: "Garcom");

            migrationBuilder.DropTable(
                name: "StatusGarcom");

            migrationBuilder.DropTable(
                name: "Cardapio");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "StatusItemPedido");

            migrationBuilder.DropTable(
                name: "Cozinha");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "StatusPedido");

            migrationBuilder.DropTable(
                name: "StatusCozinha");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "StatusMesa");
        }
    }
}
