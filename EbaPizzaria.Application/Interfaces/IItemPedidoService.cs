using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Domain.Entities;

namespace EbaPizzaria.Application.Interfaces
{
	public interface IItemPedidoService
	{
		Task<ItemPedidoDTO> Incluir(ItemPedidoDTO itensPedidoDTO);
		Task<ItemPedidoDTO> Alterar(ItemPedidoDTO itensPedidoDTO);
		Task<ItemPedidoDTO> Exlcuir(int id);
	}
}
