

using EbaPizzaria.Domain.Entities;

namespace EbaPizzaria.Domain.Interfaces
{
	public interface IClienteRepository
	{
		void Incluir(Cliente cliente);
		void Alterar(Cliente cliente);
		void Excluir(Cliente cliente);
		Task<Cliente> SelecionaById(int id);
		Task<IEnumerable<Cliente>> SelecionarTodos();
		Task<bool> SalvarTodasAlteracoes();
	}
}
