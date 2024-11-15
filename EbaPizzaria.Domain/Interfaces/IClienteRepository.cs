using EbaPizzaria.Domain.Entities;

namespace EbaPizzaria.Domain.Interfaces
{
	public interface IClienteRepository
	{
		Task<Cliente> Incluir(Cliente cliente);
		Task<Cliente> Alterar(Cliente cliente);
		Task<Cliente> Excluir(int id);
		Task<Cliente> SelecionaById(int id);
		Task<IEnumerable<Cliente>> SelecionarTodos();
		Task<bool> SalvarTodasAlteracoes();
	}
}
