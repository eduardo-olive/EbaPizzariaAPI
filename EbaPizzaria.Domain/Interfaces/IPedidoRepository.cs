using EbaPizzaria.Domain.Entities;

namespace EbaPizzaria.Domain.Interfaces;

public interface IPedidoRepository
{Task<Pedido> Incluir(Pedido pedido);
     Task<Pedido> Alterar(Pedido pedido);
     Task<Pedido> Exlcuir(int id);
     Task<IEnumerable<Pedido>> SelecionarTodos();
     Task<Pedido> SelecionarById(int id);
     Task<bool> SalvarTodasAlteracoes();    
    
}