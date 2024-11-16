using EbaPizzaria.Domain.Entities;
namespace EbaPizzaria.Domain.Interfaces
{
	public interface IUsuarioRepository
	{
		Task<Usuario> Incluir(Usuario usuario);
		Task<Usuario> Alterar(Usuario usuario);
		Task<Usuario> Excluir(int id);
		Task<Usuario> SelecionaById(int id);
		Task<IEnumerable<Usuario>> SelecionarTodos();
		Task<bool> SalvarTodasAlteracoes();
	}
}
