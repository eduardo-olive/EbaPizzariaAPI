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
	internal class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
	{
		public void Configure(EntityTypeBuilder<Pedido> builder)
		{
			builder
				.HasKey(x => x.Id);
			builder
				.Property(x => x.IdCliente)
				.IsRequired();
			builder
				.Property(x => x.DataPedido)
				.IsRequired();
			builder
				.Property(x => x.ValorPedido)
				.IsRequired();

			builder
				.HasOne(x => x.Cliente) // um cliente
				.WithMany(x => x.Pedidos) // muitos pedidos
				.HasForeignKey(x => x.IdCliente) // definição da chave estrangeira
				.OnDelete(DeleteBehavior.NoAction); // nenhuma ação para o caso do delete
		}
	}
}
