using AutoMapper;
using EbaPizzaria.API.DTOs;
using EbaPizzaria.API.Interfaces;
using EbaPizzaria.API.Models;
using EbaPizzaria.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EbaPizzaria.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClienteController : Controller
	{
		private readonly IClienteRepository _clienteRepository;
		private readonly IMapper _mapper;

		public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
			_mapper = mapper;
        }
		
		[HttpGet("selecionarTodos")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Index()
		{
			var clientes = await _clienteRepository.SelecionarTodos();
			var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
			return Ok(clientesDTO);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Cliente>> Index(int id)
		{
			Cliente cliente = await _clienteRepository.SelecionaById(id);
			if (cliente == null)
			{
				return NotFound();
			}
			
			ClienteDTO clienteDTO = _mapper.Map<ClienteDTO>(cliente);

			return Ok(clienteDTO);
		}

		[HttpPost]
		public async Task<ActionResult> CadastrarCliente(ClienteDTO clienteDTO)
		{
			var cliente = _mapper.Map<Cliente>(clienteDTO);
			_clienteRepository.Incluir(cliente);
			if (await _clienteRepository.SalvarTodasAlteracoes())
			{
				clienteDTO.Id = cliente.Id;
				return Ok(clienteDTO);
			}
			
			return BadRequest("Falha ao tentar cadastrar o cliente.");
		}

		[HttpPut]
		public async Task<ActionResult> AlterarCliente(ClienteDTO clienteDTO)
		{
			if (clienteDTO.Id == 0)
			{
				return BadRequest("Não é possivel alterar o cliente. É necessário um ID");
			}

			var clienteExiste = await _clienteRepository.SelecionaById(clienteDTO.Id);
			if (clienteExiste == null)
			{
				return NotFound("Cliente não encontrado.") ;
			}

			var cliente = _mapper.Map<Cliente>(clienteDTO);
			_clienteRepository.Alterar(cliente);
			if (await _clienteRepository.SalvarTodasAlteracoes())
			{
				return Ok(clienteDTO);
			}

			return BadRequest("FAlha ao tentar alterar o cliente.");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> ExcluirCliente(int id)
		{
			Cliente cliente = await _clienteRepository.SelecionaById(id);
			if (cliente == null)
				return NotFound();

			_clienteRepository.Excluir(cliente);
			if (await _clienteRepository.SalvarTodasAlteracoes())
			{
				return NoContent();
			}
			
			return BadRequest("Falha ao tentar excluir o cliente.");
		}
	}
}
