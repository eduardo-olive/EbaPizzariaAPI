using EbaPizzaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EbaPizzaria.Infra.Data.EntitiesConfiguration
{
	internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			builder
				.HasKey(x => x.Id);

			builder
				.Property(x => x.Nome)
				.IsRequired()
				.HasMaxLength(50);
			builder
				.Property(x => x.Endereco)
				.IsRequired()
				.HasMaxLength(50);
			builder
				.Property(x => x.Contato)
				.IsRequired()
				.HasMaxLength(15);
			
		}
	}
}
