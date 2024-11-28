using AutoMapper;
using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Application.Interfaces;
using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Domain.Interfaces;

namespace EbaPizzaria.Application.Services
{
	public class ItemPedidoService : IItemPedidoService
	{
		private readonly IItemPedidoRepository _itemPedidoRepository;
		private readonly IMapper _mapper;

		public ItemPedidoService(IItemPedidoRepository itemPedidoRepository, IMapper mapper)
		{
			_itemPedidoRepository = itemPedidoRepository;
			_mapper = mapper;
		}

		public async Task<ItemPedidoDTO> Alterar(ItemPedidoDTO itensPedidoDTO)
		{
			ItensPedido itemPedido = _mapper.Map<ItensPedido>(itensPedidoDTO);
			ItensPedido itemPedidoAlterado = await _itemPedidoRepository.Alterar(itemPedido);
			_itemPedidoRepository.SalvarTodasAlteracoes();
			return _mapper.Map<ItemPedidoDTO>(itemPedido);
		}

		public async Task<ItemPedidoDTO> Exlcuir(int id)
		{
			ItensPedido itemPedidoExcluido = await _itemPedidoRepository.Exlcuir(id);
			await _itemPedidoRepository.SalvarTodasAlteracoes();
			return _mapper.Map<ItemPedidoDTO>(itemPedidoExcluido);
		}

		public async Task<ItemPedidoDTO> Incluir(ItemPedidoDTO itensPedidoDTO)
		{
			ItensPedido itemPedido = _mapper.Map<ItensPedido>(itensPedidoDTO);
			ItensPedido itemPedidoIncluido = await _itemPedidoRepository.Incluir(itemPedido);
			await _itemPedidoRepository.SalvarTodasAlteracoes();
			return _mapper.Map<ItemPedidoDTO>(itemPedido);
		}

	}
}
