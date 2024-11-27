
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EbaPizzaria.Application.DTOs
{
	public class PedidoPostDTO
	{
		[Required(ErrorMessage = "O Id do cliente não pode ser vazio.")]
		public int IdCliente { get; set; }
		[Required(ErrorMessage = "O Valor do pedido não pode ser vazio.")]
		public decimal ValorPedido { get; set; }
		[JsonIgnore]
		public DateTime DataPedido { get; set; }
	}
}
