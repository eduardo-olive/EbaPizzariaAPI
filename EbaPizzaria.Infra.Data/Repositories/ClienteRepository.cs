using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Domain.Interfaces;
using EbaPizzaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EbaPizzaria.Infra.Data.Repositories
{
	public class ClienteRepository : IClienteRepository
	{
		private readonly ApplicationDbContext _ebaPizzariaContext;

		public ClienteRepository(ApplicationDbContext ebaPizzariaContext)
        {
            _ebaPizzariaContext = ebaPizzariaContext;
        }

        public async Task<Cliente> Alterar(Cliente cliente)
		{
			_ebaPizzariaContext.Entry(cliente).State = EntityState.Modified;
			_ebaPizzariaContext.Clientes.Update(cliente);
			return cliente;
		}

		public async Task<Cliente> Excluir(int id)
		{
			Cliente cliente = await _ebaPizzariaContext.Clientes.Where(x => x.Id == id).FirstOrDefaultAsync();
			_ebaPizzariaContext.Clientes.Remove(cliente);
			return cliente;
		}

		public async Task<Cliente> Incluir(Cliente cliente)
		{
			_ebaPizzariaContext.Clientes.Add(cliente);
			return cliente;
		}

		public async Task<bool> SalvarTodasAlteracoes()
		{
			return await _ebaPizzariaContext.SaveChangesAsync() > 0;
		}

		public async Task<Cliente> SelecionaById(int id)
		{
			return await _ebaPizzariaContext.Clientes.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Cliente>> SelecionarTodos()
		{
			IEnumerable<Cliente> clientes = await _ebaPizzariaContext.Clientes.ToListAsync();
			return clientes;
		}
	}
}
