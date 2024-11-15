using System;
using System.Collections.Generic;

namespace EbaPizzaria.Domain.Entities;

public partial class Pedido
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public DateTime DataPedido { get; set; }

    public decimal ValorPedido { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
}
