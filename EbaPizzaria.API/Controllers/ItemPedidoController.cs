using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Application.Interfaces;
using EbaPizzaria.Application.Services;
using EbaPizzaria.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EbaPizzaria.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ItemPedidoController : Controller
	{
		private readonly IItemPedidoService _itemPedidoService;
		private readonly IUsuarioService _usuarioService;

		public ItemPedidoController(IItemPedidoService itemPedidoService, IUsuarioService usuarioService)
		{
			_itemPedidoService = itemPedidoService;
			_usuarioService = usuarioService;
		}

		[HttpPost]
		public async Task<ActionResult> Incluir(ItemPedidoDTO itemPedidoDTO)
		{
			ItemPedidoDTO itemPedidoDTOIncluido = await _itemPedidoService.Incluir(itemPedidoDTO);
			if (itemPedidoDTOIncluido == null)
			{
				return BadRequest("Falha ao tentar inserir o item para o pedido: " + itemPedidoDTO.IdPedido);
			}

			return Ok(itemPedidoDTOIncluido);

		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Exluir(int id)
		{
			

			ItemPedidoDTO itemPedidoDTOExcluido = await _itemPedidoService.Exlcuir(id);
			if (itemPedidoDTOExcluido == null)
			{
				return BadRequest("Falha ao tentar remover o item do pedido");
			}

			return Ok("Item removido do pedido");
		}
	}
}
