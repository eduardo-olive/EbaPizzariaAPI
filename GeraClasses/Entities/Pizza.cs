using System;
using System.Collections.Generic;

namespace EbaPizzaria.Domain.Entities;

public partial class Pizza
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public decimal Valor { get; set; }

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();

    public virtual ICollection<Ingrediente> IdIngredientes { get; set; } = new List<Ingrediente>();
}
