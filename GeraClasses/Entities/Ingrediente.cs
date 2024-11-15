using System;
using System.Collections.Generic;

namespace EbaPizzaria.Domain.Entities;

public partial class Ingrediente
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Pizza> IdPizzas { get; set; } = new List<Pizza>();
}
