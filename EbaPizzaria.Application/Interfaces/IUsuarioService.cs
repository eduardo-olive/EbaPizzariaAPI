using EbaPizzaria.Application.DTOs;

namespace EbaPizzaria.Application.Interfaces
{
	public interface IUsuarioService
	{
		Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDTO);
		Task<UsuarioDTO> Alterar(UsuarioDTO usuarioDTO);
		Task<UsuarioDTO> Excluir(int id);
		Task<UsuarioDTO> SelecionaById(int id);
		Task<IEnumerable<UsuarioDTO>> SelecionarTodos();
	}
}
