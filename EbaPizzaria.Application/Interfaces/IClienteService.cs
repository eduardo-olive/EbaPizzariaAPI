using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Domain.Entities;

namespace EbaPizzaria.Application.Interfaces
{
	public interface IClienteService
	{
		Task<ClienteDTO> Incluir(ClienteDTO clienteDTO);
		Task<ClienteDTO> Alterar(ClienteDTO clienteDTO);
		Task<ClienteDTO> Excluir(int id);
		Task<ClienteDTO> SelecionaById(int id);
		Task<IEnumerable<ClienteDTO>> SelecionarTodos();
	}
}
