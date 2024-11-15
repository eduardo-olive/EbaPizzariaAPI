using EbaPizzaria.Domain.Validations;

namespace EbaPizzaria.Domain.Entities
{
	public class Cliente
	{
		public int Id { get; private set; }
		public string Nome { get; private set; }
		public string Endereco { get; private set; }
		public string Contato { get; private set; }
		public ICollection<Pedido> Pedidos { get; set; }

		public Cliente(int id, string nome, string endereco, string contato)
		{
			DomainExceptionValidation.When(id < 0, "O Id do cliente deve ser maior que Zero.");
			Id = id;
			ValidateClienteDomain(nome, endereco, contato);
		}

		public Cliente(string nome, string endereco, string contato)
		{
			ValidateClienteDomain(nome, endereco, contato);
		}

		public void Update(string nome, string endereco, string contato)
		{
			ValidateClienteDomain(nome, endereco, contato);
		}

		public void ValidateClienteDomain(string nome, string endereco, string contato)
		{
			DomainExceptionValidation.When(nome.Length > 50, "O Nome deve ter no máximo 50, caracteres.");
			DomainExceptionValidation.When(endereco.Length > 50, "O Endereco deve ter no máximo 50, caracteres.");
			DomainExceptionValidation.When(contato.Length > 15, "O Campo contato deve ter no máximo, 15 caracteres.");
			
			Nome = nome;
			Endereco = endereco;
			Contato = contato;
		}
	}
}
