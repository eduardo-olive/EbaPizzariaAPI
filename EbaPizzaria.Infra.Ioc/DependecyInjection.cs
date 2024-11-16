using EbaPizzaria.Application.Interfaces;
using EbaPizzaria.Application.Mappings;
using EbaPizzaria.Application.Services;
using EbaPizzaria.Domain.Interfaces;
using EbaPizzaria.Infra.Data.Context;
using EbaPizzaria.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Unicode;

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

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,

					ValidIssuer = configuration["jwt:issuer"],
					ValidAudience = configuration["jwt:audience"],
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(configuration["jwt:secretKey"])),
					ClockSkew = TimeSpan.Zero
				};
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
