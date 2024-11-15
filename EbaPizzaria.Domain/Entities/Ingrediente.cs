using EbaPizzaria.Domain.Validations;

namespace EbaPizzaria.Domain.Entities
{
	public class Ingrediente
	{
		public int Id { get; private set; }
		public string Descricao { get; private set; }
		public ICollection<IngredientesPizza> Ingredirntes { get; private set; }

		public Ingrediente(int id, string descricao)
		{
			DomainExceptionValidation.When(id < 0, "O Id do ingrediente deve ser maior que Zero.");
			Id = id;
			ValidatePizzaDomain(descricao);
		}

		public Ingrediente(string descricao)
		{
			ValidatePizzaDomain(descricao);
		}

		public void Update(string descricao)
		{
			ValidatePizzaDomain(descricao);
		}

		public void ValidatePizzaDomain(string descricao)
		{
			DomainExceptionValidation.When(descricao.Length > 150, "A Descrição pode ter no máximo, 150 caracteres.");

			Descricao = descricao;
		}
	}
}
