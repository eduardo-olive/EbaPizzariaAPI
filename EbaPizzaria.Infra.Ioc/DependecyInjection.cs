﻿using EbaPizzaria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbaPizzaria.Infra.Ioc
{
	public static class DependecyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
			IConfiguration configuration) 
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
			});

			return services;
		}
	}
}
