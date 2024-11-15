using EbaPizzaria.Domain.Entities;

namespace EbaPizzaria.Domain.Interfaces
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
