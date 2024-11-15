using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbaPizzaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    IdPizza = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => new { x.IdPedido, x.IdPizza });
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItensPedidoIdPedido = table.Column<int>(type: "int", nullable: true),
                    ItensPedidoIdPizza = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedido_ItensPedido_ItensPedidoIdPedido_ItensPedidoIdPizza",
                        columns: x => new { x.ItensPedidoIdPedido, x.ItensPedidoIdPizza },
                        principalTable: "ItensPedido",
                        principalColumns: new[] { "IdPedido", "IdPizza" });
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItensPedidoIdPedido = table.Column<int>(type: "int", nullable: true),
                    ItensPedidoIdPizza = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_ItensPedido_ItensPedidoIdPedido_ItensPedidoIdPizza",
                        columns: x => new { x.ItensPedidoIdPedido, x.ItensPedidoIdPizza },
                        principalTable: "ItensPedido",
                        principalColumns: new[] { "IdPedido", "IdPizza" });
                });

            migrationBuilder.CreateTable(
                name: "IngredientesPizza",
                columns: table => new
                {
                    IdPizza = table.Column<int>(type: "int", nullable: false),
                    IdIngrediente = table.Column<int>(type: "int", nullable: false),
                    PizzasId = table.Column<int>(type: "int", nullable: false),
                    IngredientesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientesPizza", x => new { x.IdPizza, x.IdIngrediente });
                    table.ForeignKey(
                        name: "FK_IngredientesPizza_Ingrediente_IngredientesId",
                        column: x => x.IngredientesId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientesPizza_Pizzas_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesPizza_IngredientesId",
                table: "IngredientesPizza",
                column: "IngredientesId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesPizza_PizzasId",
                table: "IngredientesPizza",
                column: "PizzasId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ItensPedidoIdPedido_ItensPedidoIdPizza",
                table: "Pedido",
                columns: new[] { "ItensPedidoIdPedido", "ItensPedidoIdPizza" });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_ItensPedidoIdPedido_ItensPedidoIdPizza",
                table: "Pizzas",
                columns: new[] { "ItensPedidoIdPedido", "ItensPedidoIdPizza" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientesPizza");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ItensPedido");
        }
    }
}
