using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Domain.Interfaces;
using EbaPizzaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EbaPizzaria.Infra.Data.Repositories
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly ApplicationDbContext _ebaPizzariaContext;

		public UsuarioRepository(ApplicationDbContext ebaPizzariaContext)
		{
			_ebaPizzariaContext = ebaPizzariaContext;
		}

		public async Task<Usuario> Alterar(Usuario usuario)
		{
			_ebaPizzariaContext.Entry(usuario).State = EntityState.Modified;
			_ebaPizzariaContext.Usuarios.Update(usuario);
			return usuario;
		}

		public async Task<Usuario> Excluir(int id)
		{
			Usuario usuario = await _ebaPizzariaContext.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
			_ebaPizzariaContext.Usuarios.Remove(usuario);
			return usuario;
		}

		public async Task<Usuario> Incluir(Usuario usuario)
		{
			_ebaPizzariaContext.Usuarios.Add(usuario);
			return usuario;
		}

		public async Task<bool> SalvarTodasAlteracoes()
		{
			return await _ebaPizzariaContext.SaveChangesAsync() > 0;
		}

		public async Task<Usuario> SelecionaById(int id)
		{
			return await _ebaPizzariaContext.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Usuario>> SelecionarTodos()
		{
			IEnumerable<Usuario> usuarios = await _ebaPizzariaContext.Usuarios.ToListAsync();
			return usuarios;
		}
	}
}
