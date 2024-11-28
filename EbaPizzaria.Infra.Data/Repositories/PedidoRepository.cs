using EbaPizzaria.Domain.Entities;
using EbaPizzaria.Domain.Interfaces;
using EbaPizzaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EbaPizzaria.Infra.Data.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly ApplicationDbContext _ebaPizzariaContext;

    public PedidoRepository(ApplicationDbContext ebaPizzariaContext)
    {
        _ebaPizzariaContext = ebaPizzariaContext;
    }

    public async Task<Pedido> Incluir(Pedido pedido)
    {
        _ebaPizzariaContext.Pedido.Add(pedido);
        return pedido;
    }

    public async Task<Pedido> Alterar(Pedido pedido)
    {
        _ebaPizzariaContext.Entry(pedido).State = EntityState.Modified;
        _ebaPizzariaContext.Pedido.Update(pedido);
        return pedido;
    }

    public async Task<Pedido> Exlcuir(int id)
    {
        Pedido pedidoExcluido = await _ebaPizzariaContext.Pedido.Where(x => x.Id == id).FirstOrDefaultAsync();
        _ebaPizzariaContext.Remove(pedidoExcluido);
        return pedidoExcluido;
    }

    public async Task<IEnumerable<Pedido>> SelecionarTodos()
    {
        IEnumerable<Pedido> pedidosSelecioandos = await _ebaPizzariaContext.Pedido.Include(x => x.Cliente).ToListAsync();
        return pedidosSelecioandos;
    }

    public Task<Pedido> SelecionarById(int id)
    {
        return _ebaPizzariaContext.Pedido.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> SalvarTodasAlteracoes()
    {
        return await _ebaPizzariaContext.SaveChangesAsync() > 0;
    }
}