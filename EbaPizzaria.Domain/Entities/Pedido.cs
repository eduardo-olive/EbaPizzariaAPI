using EbaPizzaria.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaPizzaria.Domain.Entities
{
	public class Pedido
	{
		public int Id { get; private set; }
		public int IdCliente { get; private set; }
		public DateTime DataPedido { get; private set; }
		public decimal ValorPedido { get; private set; }
		public Cliente Cliente { get; private set; }

		public Pedido(int id, int idCliente, DateTime dataPedido, decimal valorPedido)
		{
			DomainExceptionValidation.When(id < 0, "O Id do pedido deve ser maior que Zero.");
			Id = id;
			ValidatePedidoDomain(idCliente, dataPedido, valorPedido);
		}

		public Pedido(int idCliente, DateTime dataPedido, decimal valorPedido)
		{
			ValidatePedidoDomain(idCliente, dataPedido, valorPedido);
		}

		public void Update(int idCliente, DateTime dataPedido, decimal valorPedido)
		{
			ValidatePedidoDomain(idCliente, dataPedido, valorPedido);
		}

		public void ValidatePedidoDomain(int idCliente, DateTime dataPedido, decimal valorPedido)
		{
			DomainExceptionValidation.When(idCliente < 1, "O Id do cliente não pode ser menor 1.");
			
			IdCliente = idCliente;
			DataPedido = dataPedido;
			ValorPedido = valorPedido;
		}
	}
}
