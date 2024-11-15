using EbaPizzaria.Domain.Validations;

namespace EbaPizzaria.Domain.Entities
{
	public class IngredientesPizza
	{
		public int IdPizza { get; private set; }
		public int IdIngrediente {  get; private set; }
		public Pizza Pizzas { get; set; }
		public Ingrediente Ingredientes { get; set; }
		

		public IngredientesPizza(int idPizza, int idIngrediente)
		{
			ValidateIngredientePizzaDomain(idPizza, idIngrediente);	
		}

		public void ValidateIngredientePizzaDomain(int idPizza, int idIngrediente)
		{
			DomainExceptionValidation.When(idPizza < 1, "O Id da Pizza não pode ser menor que 1.");
			DomainExceptionValidation.When(idIngrediente < 1, "O Id do Ingrediente não pode ser menor que 1.");

			IdPizza = idPizza;
			IdIngrediente = idIngrediente;
		}
	}
}
