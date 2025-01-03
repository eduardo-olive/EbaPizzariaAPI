﻿using EbaPizzaria.Application.DTOs;
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

		[HttpPost]
        public async Task<ActionResult> Incluir(ClienteDTO clienteDTO)
		{
			ClienteDTO clienteDTOIncluido = await _clienteService.Incluir(clienteDTO);
			if (clienteDTOIncluido == null)
			{
				return BadRequest("Falha ao incluir o cliente.");
			}
			
			return Created();
		}

		[HttpPut]
		public async Task<ActionResult> Alterar(ClienteDTO clienteDTO)
		{
			ClienteDTO clienteDTOAlterado = await _clienteService.Alterar(clienteDTO);
			if (clienteDTOAlterado == null)
			{
				return BadRequest("Falha ao alterar o cliente.");
			}
			
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Excluir(int id)
		{
			//var userId = User.GetId;
			var userId = 16;

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

		[HttpGet]
		public async Task<ActionResult> SelecionarTodos()
		{
			IEnumerable<ClienteDTO> clientesDTOSelecionadoTodos = await _clienteService.SelecionarTodos();
			return Ok(clientesDTOSelecionadoTodos);
		}

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
