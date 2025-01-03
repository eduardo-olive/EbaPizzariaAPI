﻿using EbaPizzaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EbaPizzaria.Infra.Data.Context
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        
        public DbSet<Pizza> Pizzas { get; set; }

		public DbSet<Usuario> Usuarios { get; set; }
		
		public DbSet<Pedido> Pedido { get; set; }

		public DbSet<ItensPedido> ItensPedido { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}
