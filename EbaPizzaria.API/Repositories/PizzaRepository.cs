﻿using EbaPizzaria.API.Interfaces;
using EbaPizzaria.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EbaPizzaria.API.Repositories
{
	public class PizzaRepository : IPizzaRepository
	{
		private readonly EbaPizzariaContext _ebaPizzariaContext;

		public PizzaRepository(EbaPizzariaContext ebaPizzariaContext)
        {
            _ebaPizzariaContext = ebaPizzariaContext;
        }
        public void Alterar(Pizza pizza)
		{
			_ebaPizzariaContext.Entry(pizza).State = EntityState.Modified;
			_ebaPizzariaContext.Pizza.Update(pizza);
		}

		public void Exlcuir(Pizza pizza)
		{
			_ebaPizzariaContext.Pizza.Remove(pizza);
		}

		public void Incluir(Pizza pizza)
		{
			_ebaPizzariaContext.Pizza.Add(pizza);
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
