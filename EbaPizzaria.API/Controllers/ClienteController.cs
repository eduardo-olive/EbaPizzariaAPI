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

		public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
		
		[HttpGet("selecionarTodos")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Index()
		{
			return Ok(await _clienteRepository.SelecionarTodos());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Cliente>> Index(int id)
		{
			return Ok(await _clienteRepository.SelecionaById(id));
		}

		[HttpPost]
		public async Task<ActionResult> CadastrarCliente(Cliente cliente)
		{
			_clienteRepository.Incluir(cliente);
			if (await _clienteRepository.SalvarTodasAlteracoes())
			{
				return Ok(cliente);
			}
			
			return BadRequest("Falha ao tentar cadastrar o cliente.");
		}

		[HttpPut]
		public async Task<ActionResult> AlterarCliente(Cliente cliente)
		{
			_clienteRepository.Alterar(cliente);
			if (await _clienteRepository.SalvarTodasAlteracoes())
			{
				return Ok(cliente);
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
