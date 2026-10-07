using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChavesEstrangeiras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardapioId",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Item_CardapioId",
                table: "Item",
                column: "CardapioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Cardapio_CardapioId",
                table: "Item",
                column: "CardapioId",
                principalTable: "Cardapio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Cardapio_CardapioId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CardapioId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CardapioId",
                table: "Item");
        }
    }
}
