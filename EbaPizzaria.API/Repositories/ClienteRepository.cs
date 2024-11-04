using EbaPizzaria.API.Interfaces;
using EbaPizzaria.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EbaPizzaria.API.Repositories
{
	public class ClienteRepository : IClienteRepository
	{
		private readonly EbaPizzariaContext _ebaPizzariaContext;

		public ClienteRepository(EbaPizzariaContext ebaPizzariaContext)
        {
            _ebaPizzariaContext = ebaPizzariaContext;
        }

        public void Alterar(Cliente cliente)
		{
			_ebaPizzariaContext.Entry(cliente).State = EntityState.Modified;
			_ebaPizzariaContext.Cliente.Update(cliente);
		}

		public void Excluir(Cliente cliente)
		{
			_ebaPizzariaContext.Cliente.Remove(cliente);
		}

		public void Incluir(Cliente cliente)
		{
			_ebaPizzariaContext.Cliente.Add(cliente);
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
