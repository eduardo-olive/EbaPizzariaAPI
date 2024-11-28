using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Domain.Interfaces;
using EbaPizzaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EbaPizzaria.Infra.Data.Repositories
{
	public class ItemPedidoRepository : IItemPedidoRepository
	{
		private readonly ApplicationDbContext _ebaPizzaria;

		public ItemPedidoRepository(ApplicationDbContext ebaPizzaria)
		{
			_ebaPizzaria = ebaPizzaria;
		}

		public async Task<ItensPedido> Alterar(ItensPedido itensPedido)
		{
			_ebaPizzaria.Entry(itensPedido).State = EntityState.Modified;
			_ebaPizzaria.Update(itensPedido);
			return itensPedido;
		}

		public async Task<ItensPedido> Exlcuir(int id)
		{
			ItensPedido itensPedido = await _ebaPizzaria.ItensPedido.Where(x => x.IdPedido == id).SingleOrDefaultAsync();
			_ebaPizzaria.ItensPedido.Remove(itensPedido);
			return itensPedido;
		}

		public async Task<ItensPedido> Incluir(ItensPedido itensPedido)
		{
			_ebaPizzaria.ItensPedido.Add(itensPedido);
			return itensPedido;
		}

		public async Task<bool> SalvarTodasAlteracoes()
		{
			return await _ebaPizzaria.SaveChangesAsync() > 0;
		}

		public async Task<ItensPedido> SelecionarById(int id)
		{
			ItensPedido itemPedido = await _ebaPizzaria.ItensPedido.Where(x => x.IdPedido == id).FirstOrDefaultAsync();
			return itemPedido;
		}

		public async Task<IEnumerable<ItensPedido>> SelecionarTodos()
		{
			IEnumerable<ItensPedido> itensPedidos = await _ebaPizzaria.ItensPedido.ToListAsync();
			return itensPedidos;
		}
	}
}
