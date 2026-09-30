using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StatusCozinha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "StatusCozinha");

            migrationBuilder.AddColumn<int>(
                name: "CozinhaId",
                table: "StatusCozinha",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "StatusCozinha",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Cozinha",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusCozinha_CozinhaId",
                table: "StatusCozinha",
                column: "CozinhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusCozinha_Cozinha_CozinhaId",
                table: "StatusCozinha",
                column: "CozinhaId",
                principalTable: "Cozinha",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusCozinha_Cozinha_CozinhaId",
                table: "StatusCozinha");

            migrationBuilder.DropIndex(
                name: "IX_StatusCozinha_CozinhaId",
                table: "StatusCozinha");

            migrationBuilder.DropColumn(
                name: "CozinhaId",
                table: "StatusCozinha");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "StatusCozinha");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "StatusCozinha",
                type: "VARCHAR(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Cozinha",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
