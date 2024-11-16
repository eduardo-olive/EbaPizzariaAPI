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
	internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder
				.HasKey(x => x.Id);
			builder
				.Property(x => x.Nome)
				.IsRequired()
				.HasMaxLength(255);
			builder
				.Property(x => x.Email)
				.IsRequired()
				.HasMaxLength(255);
		}
	}
}
