using AutoMapper;
using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Application.Interfaces;
using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Domain.Interfaces;

namespace EbaPizzaria.Application.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IMapper _mapper;

    public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
    {
        _pedidoRepository = pedidoRepository;
        _mapper = mapper;
    }

    public async Task<PedidoDTO> Incluir(PedidoPostDTO pedidoPostDTO)
    {
        Pedido pedido = _mapper.Map<Pedido>(pedidoPostDTO);
        Pedido pedidoIncluido = await _pedidoRepository.Incluir(pedido);
        await _pedidoRepository.SalvarTodasAlteracoes();
        return _mapper.Map<PedidoDTO>(pedido);
    }

    public async Task<PedidoDTO> Alterar(PedidoDTO pedidoDTO)
    {
        Pedido pedido = _mapper.Map<Pedido>(pedidoDTO);
        Pedido pedidoAlterado = await _pedidoRepository.Alterar(pedido);
        await _pedidoRepository.SalvarTodasAlteracoes();
        return _mapper.Map<PedidoDTO>(pedido);
    }

    public async Task<PedidoDTO> Exlcuir(int id)
    {
        Pedido pedidoExcluido = await _pedidoRepository.Exlcuir(id);
        await _pedidoRepository.SalvarTodasAlteracoes();
        return _mapper.Map<PedidoDTO>(pedidoExcluido);
    }

    public async Task<IEnumerable<PedidoDTO>> SelecionarTodos()
    {
        IEnumerable<Pedido> pedidosSelecionados = await _pedidoRepository.SelecionarTodos();
        return _mapper.Map<IEnumerable<PedidoDTO>>(pedidosSelecionados);
    }

    public async Task<PedidoDTO> SelecionarById(int id)
    {
        Pedido pedido = await _pedidoRepository.SelecionarById(id);
        PedidoDTO PedidoDTOSelecioando = _mapper.Map<PedidoDTO>(pedido);
        return PedidoDTOSelecioando;
    }
}