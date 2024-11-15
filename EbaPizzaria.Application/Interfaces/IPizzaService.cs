using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Domain.Entities;

namespace EbaPizzaria.Application.Interfaces
{
	public interface IPizzaService
	{
		Task<PizzaDTO> Incluir(PizzaDTO pizzaDTO);
		Task<PizzaDTO> Alterar(PizzaDTO pizzaDTO);
		Task<PizzaDTO> Exlcuir(int id);
		Task<IEnumerable<PizzaDTO>> SelecionarTodos();
		Task<PizzaDTO> SelecionarById(int id);
	}
}
