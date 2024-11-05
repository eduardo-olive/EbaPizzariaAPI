using EbaPizzaria.API.Interfaces;
using EbaPizzaria.API.Models;
using EbaPizzaria.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EbaPizzaria.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PizzaController : Controller
	{
		private readonly IPizzaRepository _pizzaRepository;

		public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

		[HttpGet("selecionarTodos")]
		public async Task<ActionResult<IEnumerable<Pizza>>> Index()
		{
			return Ok(await _pizzaRepository.SelecionarTodos());	
		}
		
		[HttpGet("{id}")]
		public async Task<ActionResult<Pizza>> Index(int id)
		{
			return Ok(await _pizzaRepository.SelecionarById(id));
		}

		[HttpPost]
		public async Task<ActionResult<Pizza>> CadastrarPizza(Pizza pizza)
		{
			_pizzaRepository.Incluir(pizza);
			if (await _pizzaRepository.SalvarTodasAlteracoes()) {
				return Ok(pizza);
			}

			return BadRequest("Falha ao tentar gravar a pizza");	
		}

		[HttpPut]
		public async Task<ActionResult<Pizza>> AlterarPizza(Pizza pizza)
		{
			_pizzaRepository.Alterar(pizza);
			if (await _pizzaRepository.SalvarTodasAlteracoes()) {
				return Ok(pizza);
			}

			return BadRequest("Falha ao tentar alterar a pizza");
		}
		
		[HttpDelete("{id}")]
		public async Task<ActionResult> ExcluirPizza(int id)
		{
			Pizza pizza = await _pizzaRepository.SelecionarById(id);

			if (pizza == null)
				return NotFound();

			_pizzaRepository.Exlcuir(pizza);
			if (await _pizzaRepository.SalvarTodasAlteracoes())
			{
				return NoContent();
			}

			return BadRequest("Falha ao tentar excluir a pizza");
		}
	}
}
