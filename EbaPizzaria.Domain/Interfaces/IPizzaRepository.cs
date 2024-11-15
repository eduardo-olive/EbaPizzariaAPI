using EbaPizzaria.Domain.Entities;

namespace EbaPizzaria.Domain.Interfaces
{
	public interface IPizzaRepository
	{
		Task<Pizza> Incluir(Pizza pizza);
		Task<Pizza> Alterar(Pizza pizza);
		Task<Pizza> Exlcuir(int id);
		Task<IEnumerable<Pizza>> SelecionarTodos();
		Task<Pizza> SelecionarById(int id);
	}
}
