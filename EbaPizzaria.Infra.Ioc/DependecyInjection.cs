using EbaPizzaria.Application.Interfaces;
using EbaPizzaria.Application.Mappings;
using EbaPizzaria.Application.Services;
using EbaPizzaria.Domain.Interfaces;
using EbaPizzaria.Infra.Data.Context;
using EbaPizzaria.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EbaPizzaria.Infra.Ioc
{
	public static class DependecyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
			IConfiguration configuration) 
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				var connectionString = configuration.GetConnectionString("DefaultConnection");
				options.UseSqlServer(connectionString,
					b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
			});

			services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

			// Repositories
			services.AddScoped<IClienteRepository, ClienteRepository>();
			services.AddScoped<IPizzaRepository, PizzaRepository>();

			// Services
			services.AddScoped<IClienteService, ClienteService>();
			services.AddScoped<IPizzaService, PizzaService>();

			return services;
		}
	}
}
