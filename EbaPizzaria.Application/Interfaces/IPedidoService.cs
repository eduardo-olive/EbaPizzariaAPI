using EbaPizzaria.Application.DTOs;

namespace EbaPizzaria.Application.Interfaces;

public interface IPedidoService
{
    Task<PedidoDTO> Incluir(PedidoPostDTO pedidoPostDTO);
    Task<PedidoDTO> Alterar(PedidoPutDTO pedidoDTO);
    Task<PedidoDTO> Exlcuir(int id);
    Task<IEnumerable<PedidoDTO>> SelecionarTodos();
    Task<PedidoDTO> SelecionarById(int id); 
}