

using AutoMapper;
using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Application.Interfaces;
using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Domain.Interfaces;

namespace EbaPizzaria.Application.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _usuarioRepository;
		private readonly IMapper _mapper;

		public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
		{
			_usuarioRepository = usuarioRepository;
			_mapper = mapper;
		}

		public async Task<UsuarioDTO> Alterar(UsuarioDTO usuarioDTO)
		{
			Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
			Usuario usuarioAlterado = await _usuarioRepository.Alterar(usuario);
			await _usuarioRepository.SalvarTodasAlteracoes();
			return _mapper.Map<UsuarioDTO>(usuarioAlterado);
		}

		public async Task<UsuarioDTO> Excluir(int id)
		{
			Usuario usuarioExcluido = await _usuarioRepository.Excluir(id);
			await _usuarioRepository.SalvarTodasAlteracoes();
			return _mapper.Map<UsuarioDTO>(usuarioExcluido);
		}

		public async Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDTO)
		{
			Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
			Usuario usuarioIncluida = await _usuarioRepository.Incluir(usuario);
			_usuarioRepository.SalvarTodasAlteracoes();
			return _mapper.Map<UsuarioDTO>(usuarioIncluida);
		}

		public async Task<UsuarioDTO> SelecionaById(int id)
		{
			Usuario usuarioSelecionado = await _usuarioRepository.SelecionaById(id);
			return _mapper.Map<UsuarioDTO>(usuarioSelecionado);
		}

		public async Task<IEnumerable<UsuarioDTO>> SelecionarTodos()
		{
			IEnumerable<Usuario> usuariosSelecionados = await _usuarioRepository.SelecionarTodos();
			return _mapper.Map<IEnumerable<UsuarioDTO>>(usuariosSelecionados);
		}
	}
}
