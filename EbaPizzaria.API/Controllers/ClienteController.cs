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
		[HttpPost]
		public async Task<ActionResult> Post(Cliente cliente)
		{
			_clienteRepository.Incluir(cliente);
			if (await _clienteRepository.SalvarTodasAlteracoes())
			{
				return Ok(cliente);
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
