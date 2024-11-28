using EbaPizzaria.Domain.Entities;

namespace EbaPizzaria.Domain.Interfaces
{
    public interface IItemPedidoRepository
	{
        Task<ItensPedido> Incluir(ItensPedido itensPedido);
		Task<ItensPedido> Alterar(ItensPedido itensPedido);
		Task<ItensPedido> Exlcuir(int id);
		Task<IEnumerable<ItensPedido>> SelecionarTodos();
		Task<ItensPedido> SelecionarById(int id);
		Task<bool> SalvarTodasAlteracoes();
	}
}
