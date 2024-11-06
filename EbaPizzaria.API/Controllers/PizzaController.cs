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
	public class PizzaController : Controller
	{
		private readonly IPizzaRepository _pizzaRepository;
		private readonly IMapper _mapper;

		public PizzaController(IPizzaRepository pizzaRepository, IMapper mapper)
        {
            _pizzaRepository = pizzaRepository;
			_mapper = mapper;
        }

		[HttpGet("selecionarTodos")]
		public async Task<ActionResult<IEnumerable<PizzaDTO>>> Index()
		{
			var pizzas = await _pizzaRepository.SelecionarTodos();
			var pizzasDTO = _mapper.Map<IEnumerable<PizzaDTO>>(pizzas);
			return Ok(pizzasDTO);	
		}
		
		[HttpGet("{id}")]
		public async Task<ActionResult<PizzaDTO>> Index(int id)
		{
			Pizza pizza = await _pizzaRepository.SelecionarById(id);
			if(pizza == null)
			{
				return NotFound();
			}

			PizzaDTO pizzaDTO = _mapper.Map<PizzaDTO>(pizza);

			return Ok(pizzaDTO);
		}

		[HttpPost]
		public async Task<ActionResult> CadastrarPizza(PizzaDTO pizzaDTO)
		{
			Pizza pizza = _mapper.Map<Pizza>(pizzaDTO);
			_pizzaRepository.Incluir(pizza);
			if (await _pizzaRepository.SalvarTodasAlteracoes()) {
				pizzaDTO.Id = pizza.Id;
				return Ok(pizzaDTO);
			}

			return BadRequest("Falha ao tentar gravar a pizza");	
		}

		[HttpPut]
		public async Task<ActionResult> AlterarPizza(PizzaDTO pizzaDTO)
		{
			if (pizzaDTO.Id == 0)
				return BadRequest("Não é possivel alterar o pizza. É necessário um ID");

			Pizza pizzaExiste = await _pizzaRepository.SelecionarById(pizzaDTO.Id);
			if (pizzaExiste == null)
				return NotFound("Pizza não encontrada");
			
			Pizza pizza = _mapper.Map<Pizza>(pizzaDTO);
			_pizzaRepository.Alterar(pizza);
			if (await _pizzaRepository.SalvarTodasAlteracoes()) {
				return Ok(pizzaDTO);
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
