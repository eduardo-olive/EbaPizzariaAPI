using EbaPizzaria.API.Models;

namespace EbaPizzaria.API.Interfaces
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
