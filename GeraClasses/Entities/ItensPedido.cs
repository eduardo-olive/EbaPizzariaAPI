using System;
using System.Collections.Generic;

namespace EbaPizzaria.Domain.Entities;

public partial class ItensPedido
{
    public int IdPedido { get; set; }

    public int IdPizza { get; set; }

    public decimal ValorUnitario { get; set; }

    public int Quantidade { get; set; }

    public decimal ValorTotal { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Pizza IdPizzaNavigation { get; set; } = null!;
}
