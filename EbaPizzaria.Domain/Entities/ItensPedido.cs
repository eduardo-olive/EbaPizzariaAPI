using EbaPizzaria.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaPizzaria.Domain.Entities
{
	public class ItensPedido
	{
		public int IdPedido { get; private set; }
		public int IdPizza { get; private set; }
		public decimal ValorUnitario { get; private set; }
		public int Quantidade {  get; private set; }
		public decimal ValorTotal { get; private set; }
		public ICollection<Pedido> Pedidos {  get; set; }
		public ICollection<Pizza> Pizzas { get; set; }

		public ItensPedido(int idPedido, int idPizza, decimal valorUnitario, int quantidade, decimal valorTotal)
		{
			ValidateItensPedidoDomain(idPedido, idPizza, valorUnitario, quantidade, valorTotal);
		}

		public void Update(int idPedido, int idPizza, decimal valorUnitario, int quantidade, decimal valorTotal)
		{
			ValidateItensPedidoDomain(idPedido, idPizza, valorUnitario, quantidade, valorTotal);
		}

		public void ValidateItensPedidoDomain(int idPedido, int idPizza, decimal valorUnitario, int quantidade, decimal valorTotal)
		{
			DomainExceptionValidation.When(idPedido < 1, "O Id do Pedido não pode ser menor que 1");
			DomainExceptionValidation.When(idPizza < 1, "O Id da Pizza não pode ser menor que 1");

			IdPedido = idPedido;
			IdPizza = idPizza;
			ValorUnitario = valorUnitario;
			Quantidade = quantidade;
			ValorTotal = valorTotal;
		}
	}
}
