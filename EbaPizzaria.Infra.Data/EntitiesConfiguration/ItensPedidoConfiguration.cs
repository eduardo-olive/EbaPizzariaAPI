using EbaPizzaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaPizzaria.Infra.Data.EntitiesConfiguration
{
	internal class ItensPedidoConfiguration : IEntityTypeConfiguration<ItensPedido>
	{
		public void Configure(EntityTypeBuilder<ItensPedido> builder)
		{
			builder
				.HasKey(x => new { x.IdPedido, x.IdPizza });
			
			builder
				.Property(x => x.ValorUnitario)
				.IsRequired();
			
			builder
				.Property(x => x.Quantidade)
				.IsRequired();
			
			builder
				.Property(x => x.ValorTotal)
				.IsRequired();
		}
	}
}
