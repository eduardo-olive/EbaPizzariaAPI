
using System.ComponentModel.DataAnnotations;

namespace EbaPizzaria.Application.DTOs
{
	public class PedidoPutDTO
	{
		[Required(ErrorMessage = "O Identificador do pedido é obrigatório.")]
		public int Id { get; set; }

		public decimal ValorPedido { get; set; }
		// o que vai ser alterado alem do valor do pedido serão os itens que
		// no caso são as pizzas pedidas.
	}
}
