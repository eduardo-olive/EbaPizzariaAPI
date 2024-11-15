using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EbaPizzaria.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PizzaController : Controller
	{
		private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
			_pizzaService = pizzaService;
        }

		[HttpPost]
        public async Task<IActionResult> IncluirPizza(PizzaDTO pizzaDTO)
		{
			PizzaDTO pizzaDTOInserida = await _pizzaService.Incluir(pizzaDTO);
			if (pizzaDTOInserida == null)
			{
				return BadRequest("Falha ao tentar inserir a pizza.");
			}
			
			return Ok(pizzaDTOInserida);
		}

		[HttpPut]
		public async Task<ActionResult> AlterarPizza(PizzaDTO pizzaDTO)
		{
			PizzaDTO pizzaDTOAlterada = await _pizzaService.Alterar(pizzaDTO);
			if (pizzaDTOAlterada == null)
			{
				return BadRequest("Falha ao tentar alterar a pizza.");
			}

			return Ok(pizzaDTOAlterada);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> ExcluirPizza(int id)
		{
			PizzaDTO pizzaDTOExcluida = await _pizzaService.Exlcuir(id);
			if (pizzaDTOExcluida == null)
			{
				return BadRequest("Falha ao tentar excluir a pizza");
			}

			return Ok("Pizza Excluida com sucesso.");

		}

		[HttpGet("{id}")]
		public async Task<ActionResult> SelecionarPorId(int id)
		{
			PizzaDTO PizzaDTOSelecionado = await _pizzaService.SelecionarById(id);
			if (PizzaDTOSelecionado == null)
			{
				return NotFound("Pizza não localizada.");
			}
			return Ok(PizzaDTOSelecionado);
		}

		[HttpGet]
		public async Task<ActionResult> SelecionarTodos()
		{
			IEnumerable<PizzaDTO> PizzaDTOSelecionado = await _pizzaService.SelecionarTodos();
			return Ok(PizzaDTOSelecionado);
		}
	}
}
