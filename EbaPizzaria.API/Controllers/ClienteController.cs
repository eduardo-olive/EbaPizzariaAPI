using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Application.Interfaces;
using EbaPizzaria.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EbaPizzaria.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class ClienteController : Controller
	{
		private readonly IClienteService _clienteService;
		private readonly IUsuarioService _usuarioService;

		public ClienteController(IUsuarioService suarioService, IClienteService clienteService)
		{
			_usuarioService = suarioService;
			_clienteService = clienteService;
		}

		/// <summary>
		/// Inclui um cliente.
		/// </summary>
		/// <remarks>
		/// {
		///	  "id": 0,
		///	  "nome": "string",
		///	  "endereco": "string",
		///	  "contato": "string"
		///	}
		/// </remarks>
		/// <param name="clienteDTO">Dados do cliente</param>
		/// <returns>Objeto recém-criando</returns>
		/// <response code="400">Falha ao incluir cliente</response>
		/// <response code="201">Sucesso</response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Incluir(ClienteDTO clienteDTO)
		{
			ClienteDTO clienteDTOIncluido = await _clienteService.Incluir(clienteDTO);
			if (clienteDTOIncluido == null)
			{
				return BadRequest("Falha ao incluir o cliente.");
			}
			
			return Created();
		}

		/// <summary>
		/// Altera cliente.
		/// </summary>
		/// <remarks>
		/// {
		///	  "id": 0,
		///	  "nome": "string",
		///	  "endereco": "string",
		///	  "contato": "string"
		///	} 
		/// </remarks>
		/// <param name="id">Identificador do cliente</param>
		/// <param name="clienteDTO">Dados do cliente</param>
		/// <returns>Nada.</returns>
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> Alterar(int id, ClienteDTO clienteDTO)
		{
			ClienteDTO clienteDTOAlterado = await _clienteService.Alterar(clienteDTO);
			if (clienteDTOAlterado == null)
			{
				return BadRequest("Falha ao alterar o cliente.");
			}
			
			return NoContent();
		}

		/// <summary>
		/// Deleta um cliente.
		/// </summary>
		/// <param name="id">Identificador do cliente.</param>
		/// <returns></returns>
		/// <response code="401">Não autorizado</response>
		/// <response code="400">Falha na exclusão do cliente.</response>
		/// <response code="201">Sucesso</response>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public async Task<ActionResult> Excluir(int id)
		{
			var userId = User.GetId();

			UsuarioDTO usuarioDTO = await _usuarioService.SelecionaById(userId);

			if (!usuarioDTO.IsAdmin)
			{
				return Unauthorized("Usuário sem permissão para executar essa tarefa.");
			}
			
			ClienteDTO clienteDTOExcluido = await _clienteService.Excluir(id);
			if (clienteDTOExcluido == null)
			{
				return BadRequest("Falha ao excluir o cliente.");
			}

			return NoContent();
		}

		/// <summary>
		/// Obter todos os clientes
		/// </summary>
		/// <remarks>
		/// array de clientes JSON
		/// </remarks>
		/// <returns>Coleção de cliente.</returns>
		/// <response code="200">Sucesso</response>
		[HttpGet]
		public async Task<ActionResult> SelecionarTodos()
		{
			IEnumerable<ClienteDTO> clientesDTOSelecionadoTodos = await _clienteService.SelecionarTodos();
			return Ok(clientesDTOSelecionadoTodos);
		}

		/// <summary>
		/// Obter um cliente através do identificador.
		/// </summary>
		/// <remarks>
		/// retorna um cliente.
		/// </remarks>
		/// <param name="id">Identificador do cliente</param>
		/// <returns>Retorna um cliente</returns>
		/// <response code="200">Sucesso</response>
		/// <response code="404">Não encontrado</response>
		[HttpGet("{id}")]
		public async Task<ActionResult> SelecionarPorId(int id)
		{
			ClienteDTO clienteDTOSelecionado = await _clienteService.SelecionaById(id);
			if (clienteDTOSelecionado == null)
			{
				return NotFound("Cliente não encontrado.");
			}
			
			return Ok(clienteDTOSelecionado);
		}
	}
}
