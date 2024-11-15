using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Domain.Interfaces;
using EbaPizzaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EbaPizzaria.Infra.Data.Repositories
{
	public class PizzaRepository : IPizzaRepository
	{
		private readonly ApplicationDbContext _ebaPizzariaContext;

		public PizzaRepository(ApplicationDbContext ebaPizzariaContext)
        {
            _ebaPizzariaContext = ebaPizzariaContext;
        }
        public async Task<Pizza> Alterar(Pizza pizza)
		{
			_ebaPizzariaContext.Entry(pizza).State = EntityState.Modified;
			_ebaPizzariaContext.Pizza.Update(pizza);
			return pizza;
		}

		public async Task<Pizza> Exlcuir(int id)
		{
			Pizza pizzaExcluida = await _ebaPizzariaContext.Pizza.Where(x => x.Id == id).FirstOrDefaultAsync();
			_ebaPizzariaContext.Pizza.Remove(pizzaExcluida);
			return pizzaExcluida;
		}

		public async Task<Pizza> Incluir(Pizza pizza)
		{
			_ebaPizzariaContext.Pizza.Add(pizza);
			return pizza;
		}

		public async Task<bool> SalvarTodasAlteracoes()
		{
			return await _ebaPizzariaContext.SaveChangesAsync() > 0;
		}

		public async Task<Pizza> SelecionarById(int id)
		{
			return await _ebaPizzariaContext.Pizza.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Pizza>> SelecionarTodos()
		{
			return await _ebaPizzariaContext.Pizza.ToListAsync();
		}
	}
}
