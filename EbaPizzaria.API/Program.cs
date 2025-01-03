using EbaPizzaria.Infra.Ioc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddInfrastructureSwagger();
builder.Services.AddSwaggerGen(sw => 
{
	sw.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "EbaPizzaria.API",
		Version = "v1",
		Contact = new OpenApiContact
		{
			Name = "Eduardo Oliveira",
			Email = "oliveira.eduardo.dev@gmail.com",
			Url = new Uri("https://eduardodev.com.br")
		},
	});

	var xmlFile = "EbaPizzaria.API.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	sw.IncludeXmlComments(xmlPath);
});

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EbaPizzaria.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
