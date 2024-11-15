
using EbaPizzaria.Domain.Validations;
using System.Drawing;

namespace EbaPizzaria.Domain.Entities
{
	public class Pizza
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set;}
		public decimal Valor { get; set; }
		public ICollection<IngredientesPizza> IngredientesPizza { get; set; }

		public Pizza(int id, string nome, string descricao, decimal valor)
		{
			DomainExceptionValidation.When(id < 0, "O Id da pizza deve ser maior que Zero.");
			Id = id;
			ValidatePizzaDomain(nome, descricao, valor);
		}

		public Pizza(string nome, string descricao, decimal valor)
		{
			ValidatePizzaDomain(nome, descricao, valor);
		}

		public void Update(string nome, string descricao, decimal valor)
		{
			ValidatePizzaDomain(nome, descricao, valor);
		}

		public void ValidatePizzaDomain(string nome, string descricao, decimal valor)
		{
			DomainExceptionValidation.When(nome.Length > 30, "O Nome deve ter no máximo, 30 caracteres.");
			DomainExceptionValidation.When(descricao.Length > 255, "A Descrição deve ter no máximo, 255 caracteres.");
			DomainExceptionValidation.When(valor <= 0, "O Valor não pode ser menor que Zero.");

			Nome = nome;
			Descricao = descricao;
			Valor = valor;
		}
	}
}
