using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbaPizzaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class MudancaNosRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientesPizza_Ingrediente_IngredientesId",
                table: "IngredientesPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientesPizza_Pizzas_PizzasId",
                table: "IngredientesPizza");

            migrationBuilder.DropIndex(
                name: "IX_IngredientesPizza_IngredientesId",
                table: "IngredientesPizza");

            migrationBuilder.DropIndex(
                name: "IX_IngredientesPizza_PizzasId",
                table: "IngredientesPizza");

            migrationBuilder.DropColumn(
                name: "IngredientesId",
                table: "IngredientesPizza");

            migrationBuilder.DropColumn(
                name: "PizzasId",
                table: "IngredientesPizza");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "Pedido",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "IngredienteId",
                table: "IngredientesPizza",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "IngredientesPizza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesPizza_IngredienteId",
                table: "IngredientesPizza",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesPizza_PizzaId",
                table: "IngredientesPizza",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientesPizza_Ingrediente_IngredienteId",
                table: "IngredientesPizza",
                column: "IngredienteId",
                principalTable: "Ingrediente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientesPizza_Pizzas_PizzaId",
                table: "IngredientesPizza",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientesPizza_Ingrediente_IngredienteId",
                table: "IngredientesPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientesPizza_Pizzas_PizzaId",
                table: "IngredientesPizza");

            migrationBuilder.DropIndex(
                name: "IX_IngredientesPizza_IngredienteId",
                table: "IngredientesPizza");

            migrationBuilder.DropIndex(
                name: "IX_IngredientesPizza_PizzaId",
                table: "IngredientesPizza");

            migrationBuilder.DropColumn(
                name: "IngredienteId",
                table: "IngredientesPizza");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "IngredientesPizza");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataPedido",
                table: "Pedido",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "IngredientesId",
                table: "IngredientesPizza",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PizzasId",
                table: "IngredientesPizza",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesPizza_IngredientesId",
                table: "IngredientesPizza",
                column: "IngredientesId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesPizza_PizzasId",
                table: "IngredientesPizza",
                column: "PizzasId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientesPizza_Ingrediente_IngredientesId",
                table: "IngredientesPizza",
                column: "IngredientesId",
                principalTable: "Ingrediente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientesPizza_Pizzas_PizzasId",
                table: "IngredientesPizza",
                column: "PizzasId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
