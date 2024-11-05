﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EbaPizzaria.API.Models;

public partial class Pizza
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    [Unicode(false)]
    public string Nome { get; set; }

    [Required]
    [StringLength(255)]
    [Unicode(false)]
    public string Descricao { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal Valor { get; set; }

    [InverseProperty("IdPizzaNavigation")]
    public virtual ICollection<ItensPedido> ItensPedido { get; set; } = new List<ItensPedido>();

    [ForeignKey("IdPizza")]
    [InverseProperty("IdPizza")]
    public virtual ICollection<Ingredientes> IdIngrediente { get; set; } = new List<Ingredientes>();
}