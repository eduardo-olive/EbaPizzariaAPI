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
	internal class IngredienteConfiguration : IEntityTypeConfiguration<Ingrediente>
	{
		public void Configure(EntityTypeBuilder<Ingrediente> builder)
		{
			builder
				.HasKey(x => x.Id);
			builder
				.Property(x => x.Descricao)
				.IsRequired()
				.HasMaxLength(150);

		}
	}
}
