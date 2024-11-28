
using System.ComponentModel.DataAnnotations;
namespace EbaPizzaria.Application.DTOs
{
	public class ItemPedidoDTO
	{
		[Required(ErrorMessage = "O Identificador do pedido é obirgatório.")]
		public int IdPedido { get; set; }
		[Required(ErrorMessage = "O Identificador do da pizza é obirgatório.")]
		public int IdPizza { get; set; }
		public decimal ValorUnitario { get; set; }
		public int Quantidade { get; set; }
		public decimal ValorTotal { get; set; }
	}
}
