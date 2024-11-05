using EbaPizzaria.API.Models;

namespace EbaPizzaria.API.Interfaces
{
	public interface IPizzaRepository
	{
		void Incluir(Pizza pizza);
		void Alterar(Pizza pizza);
		void Exlcuir(Pizza pizza);
		Task<IEnumerable<Pizza>> SelecionarTodos();
		Task<Pizza> SelecionarById(int id);
		Task<bool> SalvarTodasAlteracoes();
	}
}
