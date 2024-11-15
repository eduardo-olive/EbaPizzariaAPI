using EbaPizzaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EbaPizzaria.Infra.Data.EntitiesConfiguration
{
	internal class IngredientesPIzzaConfiguration : IEntityTypeConfiguration<IngredientesPizza>
	{
		public void Configure(EntityTypeBuilder<IngredientesPizza> builder)
		{
			builder
				.HasKey(x => new { x.IdPizza , x.IdIngrediente });
		}
	}
}
