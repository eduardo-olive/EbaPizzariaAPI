using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaPizzaria.Infra.Ioc
{
	public static class DepedencyInjectionSwagger
	{
		public static IServiceCollection AddInfrastructureSwagger(this  IServiceCollection services)
		{
			services.AddSwaggerGen(c => 
			{ 
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT (JSON Web Token) é um padrão aberto que permite a transmissão segura de informações entre partes, como um objeto JSON"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme
						()
						{
							Reference = new OpenApiReference()
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						new String[] {}
					}
				});

			});
			
			return services;
		}
	}
}
