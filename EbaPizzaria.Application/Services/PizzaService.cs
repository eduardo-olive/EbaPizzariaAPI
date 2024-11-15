using AutoMapper;
using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Application.Interfaces;
using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Domain.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace EbaPizzaria.Application.Services
{
	internal class PizzaService : IPizzaService
	{
		private readonly IPizzaRepository _pizzaRepository;
		private readonly IMapper _mapper;

        public PizzaService(IPizzaRepository pizzaRepository, IMapper mapper)
        {
            _pizzaRepository = pizzaRepository;
			_mapper = mapper;
        }
        public async Task<PizzaDTO> Alterar(PizzaDTO pizzaDTO)
		{
			Pizza pizza = _mapper.Map<Pizza>(pizzaDTO);
			Pizza pizzaAlterada = await _pizzaRepository.Alterar(pizza);
			return _mapper.Map<PizzaDTO>(pizzaAlterada);
		}

		public async Task<PizzaDTO> Exlcuir(int id)
		{
			Pizza pizzaExcluida = await _pizzaRepository.Exlcuir(id);
			return _mapper.Map<PizzaDTO>(pizzaExcluida);
		}

		public async Task<PizzaDTO> Incluir(PizzaDTO pizzaDTO)
		{
			Pizza pizza = _mapper.Map<Pizza>(pizzaDTO);
			Pizza pizzaIncluida = await _pizzaRepository.Incluir(pizza);
			return _mapper.Map<PizzaDTO>(pizzaIncluida);
		}

		public async Task<PizzaDTO> SelecionarById(int id)
		{
			Pizza pizzaSelecionada = await _pizzaRepository.SelecionarById(id);
			return _mapper.Map<PizzaDTO>(pizzaSelecionada);
		}

		public async Task<IEnumerable<PizzaDTO>> SelecionarTodos()
		{
			IEnumerable<Pizza> pizzasSelecionadas = await _pizzaRepository.SelecionarTodos();
			return _mapper.Map<IEnumerable<PizzaDTO>>(pizzasSelecionadas);
		}
	}
}
