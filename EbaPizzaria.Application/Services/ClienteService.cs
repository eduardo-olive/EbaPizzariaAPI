using AutoMapper;
using EbaPizzaria.Application.DTOs;
using EbaPizzaria.Application.Interfaces;
using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Domain.Interfaces;

namespace EbaPizzaria.Application.Services
{
	public class ClienteService : IClienteService
	{
		private readonly IClienteRepository _clienteRepository;
		private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
			_clienteRepository = clienteRepository;
			_mapper = mapper;
        }

        public async Task<ClienteDTO> Alterar(ClienteDTO clienteDTO)
		{
			Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
			Cliente clienteAlterado = await _clienteRepository.Alterar(cliente);
			await _clienteRepository.SalvarTodasAlteracoes();
			return _mapper.Map<ClienteDTO>(clienteAlterado);
		}

		public async Task<ClienteDTO> Excluir(int id)
		{
			Cliente clienteExcluido = await _clienteRepository.Excluir(id);
			await _clienteRepository.SalvarTodasAlteracoes();
			return _mapper.Map<ClienteDTO>(clienteExcluido);
		}

		public async Task<ClienteDTO> Incluir(ClienteDTO clienteDTO)
		{
			Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
			Cliente clienteIncluido = await _clienteRepository.Incluir(cliente);
			await _clienteRepository.SalvarTodasAlteracoes();
			
			return _mapper.Map<ClienteDTO>(clienteIncluido);
		}

		public async Task<ClienteDTO> SelecionaById(int id)
		{
			Cliente clienteSelecionado = await _clienteRepository.SelecionaById(id);
			return _mapper.Map<ClienteDTO>(clienteSelecionado);
		}

		public async Task<IEnumerable<ClienteDTO>> SelecionarTodos()
		{
			IEnumerable<Cliente> clientesSelecionados = await _clienteRepository.SelecionarTodos();
			return _mapper.Map<IEnumerable<ClienteDTO>>(clientesSelecionados);
		}
	}
}
