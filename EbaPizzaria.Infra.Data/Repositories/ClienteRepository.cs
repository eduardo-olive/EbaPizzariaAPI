using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Domain.Interfaces;
using EbaPizzaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

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
			_ebaPizzariaContext.Cliente.Update(cliente);
			return cliente;
		}

		public async Task<Cliente> Excluir(int id)
		{
			Cliente cliente = await _ebaPizzariaContext.Cliente.Where(x => x.Id == id).FirstOrDefaultAsync();
			_ebaPizzariaContext.Cliente.Remove(cliente);
			return cliente;
		}

		public async Task<Cliente> Incluir(Cliente cliente)
		{
			_ebaPizzariaContext.Cliente.Add(cliente);
			return cliente;
		}

		public async Task<bool> SalvarTodasAlteracoes()
		{
			return await _ebaPizzariaContext.SaveChangesAsync() > 0;
		}

		public async Task<Cliente> SelecionaById(int id)
		{
			return await _ebaPizzariaContext.Cliente.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Cliente>> SelecionarTodos()
		{
			return await _ebaPizzariaContext.Cliente.ToListAsync();
		}
	}
}
